using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, IOccupiesTile
{
    public Vector2Int localForward;
    public Vector2Int localRight;
    public Vector2Int localBack;
    public Vector2Int localLeft;
    public Vector2Int mapPosition { get; set; }
    public MapGenerator mapGenerator;
    [SerializeField]
    private InputActionAsset controls;
    private Vector2 input;
    private float turnInput;
    bool isActionable;
    [SerializeField]
    const float MOVE_TIME = 0.1F;
    const float MOVE_COOLDOWN_TIME = 0.02F;
    const float MOVE_DISTANCE = 5;

    void Awake()
    {
        localForward = new Vector2Int(0, 1);
        localBack = new Vector2Int(0, -1);
        localRight = new Vector2Int(1, 0);
        localLeft = new Vector2Int(-1, 0);
        input = new Vector2();
        turnInput = 0;
        isActionable = true;
    }

    private void FixedUpdate()
    {
        // read input and poll for movement
        turnInput = controls
                .FindActionMap("Player")
                .FindAction("Turn")
                .ReadValue<float>();
        attemptTurn(turnInput);

        input = controls
                .FindActionMap("Player")
                .FindAction("Movement")
                .ReadValue<Vector2>();
        attemptMove(input);
    }

    ///  <summary>
    ///  Called in the fixed update loop. Uses the already read input values
    ///  and moves the player in the direction they press.
    /// </summary>
    /// <param name="userInput">
    /// A Vector2 variable representing the user input with a range from 0-1 for the x and y axis.
    /// </param>
    void attemptMove(Vector2 userInput)
    {
        if (!isActionable)
        {
            return;
        }

        if (userInput.y > 0.5 && isValidMove(localForward)) // move forwards
        {
            Debug.Log("move forward");
            StartCoroutine(movePlayer(localForward));
            mapPosition += localForward;
        }
        else if (userInput.y < -0.5 && isValidMove(localBack)) // move backwards
        {

            StartCoroutine(movePlayer(localBack));
            mapGenerator.map.placeCharacter(mapPosition, localBack, gameObject.GetComponent<PlayerMovement>());
            mapPosition += localBack;
        }
        else if (userInput.x > 0.5 && isValidMove(localRight)) // move right
        {
            StartCoroutine(movePlayer(localRight));
            mapGenerator.map.placeCharacter(mapPosition, localRight, gameObject.GetComponent<PlayerMovement>());
            mapPosition += localRight; // add direction to the map position
        }
        else if (userInput.x < -0.5 && isValidMove(localLeft)) // move left
        {
            StartCoroutine(movePlayer(localLeft));
            mapGenerator.map.placeCharacter(mapPosition, localLeft, gameObject.GetComponent<PlayerMovement>());
            mapPosition += localLeft;
        }
    }

    /// <summary>
    /// Called in the fixed update loop. Reads the already read controller input and moves
    /// the player in the direction they press.
    /// </summary>
    /// <param name="turnInput">The user input ranging from -1 (left) to 1 (right).</param>
    void attemptTurn(float turnInput)
    {
        if (!isActionable)
        {
            return;
        }

        if (turnInput > 0.5)
        {
            StartCoroutine(turnPlayer(transform.right));
            turnLocalFacingRight();
        }
        else if (turnInput < -0.5)
        {
            StartCoroutine(turnPlayer(-transform.right));
            turnLeftLocalFacing();
        }
    }

    /// <summary>
    /// A coroutine that turns the player a quarter turn on it's right-facing  or left-facing direction.
    /// </summary>
    /// <param name="direction">A Vector3 direction for which direction to turn the player.</param>
    /// <returns>Is a coroutine. Returns a coroutine yield.</returns>
    public IEnumerator turnPlayer(Vector3 direction)
    {
        if (!isActionable)
        {
            yield break;
        }

        isActionable = false;
        Quaternion startPoint = transform.localRotation;
        Quaternion endPoint = transform.localRotation;
        endPoint.SetLookRotation(direction);
        float elapsedTime = 0;
        // MovementEventHandler.playerTurned(endPoint);
        broadCastPlayerTurned(endPoint);
        while (elapsedTime < MOVE_TIME)
        {
            transform.localRotation =
                Quaternion.Lerp(startPoint, endPoint, (elapsedTime / MOVE_TIME));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localRotation = endPoint;
        yield return new WaitForSeconds(MOVE_COOLDOWN_TIME);
        isActionable = true;
    }

    private void broadCastPlayerTurned(Quaternion endPoint)
    {
        MovementEventHandler.playerTurned(MovementEventHandler.quaternionTo2D(endPoint));
    }

    /// <summary>
    /// When turning right, converts the current facing direction to match the map's absolute facing directions.
    /// </summary>
    private void turnLocalFacingRight()
    {
        Vector2Int tempF = localForward;
        Vector2Int tempR = localRight;
        Vector2Int tempB = localBack;
        Vector2Int tempL = localLeft;
        localForward = tempR;
        localRight = tempB;
        localBack = tempL;
        localLeft = tempF;
    }

    /// <summary>
    /// When turning left, converts the current facing direction to match the map's absolute facing directions.
    /// </summary>
    private void turnLeftLocalFacing()
    {
        Vector2Int tempF = localForward;
        Vector2Int tempR = localRight;
        Vector2Int tempB = localBack;
        Vector2Int tempL = localLeft;
        localForward = tempL;
        localRight = tempF;
        localBack = tempR;
        localLeft = tempB;
    }

    /// <summary>
    /// A coroutine that moves the player in the direction they input. They can move
    /// forward, back, left, and right.
    /// </summary>
    /// <param name="direction">A Vector3 direction for which direction to move the player.</param>
    /// <returns>Is a coroutine. Returns a coroutine yield.</returns>
    public IEnumerator movePlayer(Vector2Int direction)
    {
        if (!isActionable)
        {
            yield break;
        }
        isActionable = false;
        // place the character on the map and send the playermoved event
        mapGenerator.map.placeCharacter(mapPosition, direction, gameObject.GetComponent<PlayerMovement>());

        Vector3 v3direction = new Vector3(direction.x, 0, direction.y);
        Vector3 startPoint = transform.localPosition;
        Vector3 endPoint =
            transform.localPosition + (v3direction * MOVE_DISTANCE);
        float elapsedTime = 0;
        while (elapsedTime < MOVE_TIME)
        {
            transform.localPosition =
                Vector3.Lerp(startPoint, endPoint, (elapsedTime / MOVE_TIME));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = endPoint;
        yield return new WaitForSeconds(MOVE_COOLDOWN_TIME);
        isActionable = true;
    }

    /// <summary>
    /// The method isValidMove returns a boolean value depenidng on whether
    /// the intended move is valid or not.
    /// </summary>
    /// <param name="moveDir">The intended move direction the player wants to move in.</param>
    /// <returns>A boolean true if the intended move direction is legal/valid. False if the intended move is illegal/invalid.</returns>
    public bool isValidMove(Vector2Int moveDir)
    {
        Debug.Log(mapPosition + " " + moveDir);
        Tile tile = mapGenerator.map.getTile(mapPosition, moveDir);
        Debug.Log(tile);
        // Written as nested if statements to ensure no null reference exception
        if (tile != null)
        {
            if (tile.properties.ContainsKey("isFloor"))
            {
                return true;
            }
        }
        return false;
    }

    public void placePlayer(Vector2Int position, Vector2Int facingDir)
    {
        faceDirection(facingDir);
        mapPosition = position;

        Debug.Log(mapPosition);
        Vector3 newPos = new Vector3(); // adjust the physical transform to match the coordinates on the map
        newPos.x = position.x * MOVE_DISTANCE;
        newPos.z = position.y * MOVE_DISTANCE;
        transform.position = newPos;

        MovementEventHandler.playerMoved(mapPosition);
    }



    private void faceDirection(Vector2Int facingDir)
    {
        // not gonna lie this is just a magic formula
        localForward = facingDir;
        localBack = facingDir * -1;
        localLeft.x = localBack.y;
        localLeft.y = localBack.x;
        localRight.x = localForward.y;
        localRight.y = localForward.x;
        Vector3 endRotation = new Vector3(facingDir.x, 0, facingDir.y);
        Quaternion endDir = transform.localRotation;
        endDir.SetLookRotation(endRotation);
        transform.localRotation = endDir;

        MovementEventHandler.playerTurned(MovementEventHandler.quaternionTo2D(endDir));
    }


}
