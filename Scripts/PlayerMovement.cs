using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, ICharacter
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
    bool isFloor;
    [SerializeField]
    const float MOVE_TIME = 0.3F;
    const float MOVE_COOLDOWN_TIME = 0.05F;
    const float MOVE_DISTANCE = 5;

    void Start()
    {
        localForward = new Vector2Int(0, 1);
        localBack = new Vector2Int(0, -1);
        localRight = new Vector2Int(1, 0);
        localLeft = new Vector2Int(-1, 0);
        mapPosition = new Vector2Int(0, 0);
        input = new Vector2();
        turnInput = 0;
        isActionable = true;
        isFloor = true;
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
    /// <param name="userInput"></param>
    void attemptMove(Vector2 userInput)
    {
        if (!isActionable)
        {
            return;
        }

        if (isActionable) return;

        if (userInput.y > 0.5 && isValidMove(localForward)) // move forwards
        {
            StartCoroutine(movePlayer(transform.forward));
            mapGenerator.map.placeCharacter(mapPosition, localForward, gameObject.GetComponent<PlayerMovement>());
            mapPosition += localForward;
        }
        else if (userInput.y < -0.5 && isValidMove(localBack)) // move backwards
        {

            StartCoroutine(movePlayer(-transform.forward));
            mapGenerator.map.placeCharacter(mapPosition, localBack, gameObject.GetComponent<PlayerMovement>());
            mapPosition += localBack;
        }
        else if (userInput.x > 0.5 && isValidMove(localRight)) // move right
        {
            StartCoroutine(movePlayer(transform.right));
            mapGenerator.map.placeCharacter(mapPosition, localRight, gameObject.GetComponent<PlayerMovement>());
            mapPosition += localRight;
        }
        else if (userInput.x < -0.5 && isValidMove(localLeft)) // move left
        {
            StartCoroutine(movePlayer(-transform.right));
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
            turnRightLocalFacing();
        }
        else if (turnInput < -0.5)
        {
            StartCoroutine(turnPlayer(-transform.right));
            turnLeftLocalFacing();
        }
    }

    /// <summary>
    /// A coroutine that moves the player in the

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
        while (elapsedTime < MOVE_TIME)
        {
            transform.localRotation =
                Quaternion
                    .Lerp(startPoint, endPoint, (elapsedTime / MOVE_TIME));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localRotation = endPoint;
        yield return new WaitForSeconds(MOVE_COOLDOWN_TIME);
        isActionable = true;
    }

    private void turnRightLocalFacing()
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
    public IEnumerator movePlayer(Vector3 direction)
    {
        if (!isActionable)
        {
            yield break;
        }
        isActionable = false;
        Vector3 startPoint = transform.localPosition;
        Vector3 endPoint =
            transform.localPosition + (direction * MOVE_DISTANCE);
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
        Tile tile = mapGenerator.map.getTile(mapPosition, moveDir);
        try
        {
            if (tile.isFloor && tile != null)
            {
                return true;
            }
        }
        catch (System.NullReferenceException ex)
        {
            Debug.Log("Null tile reference: " + ex);
        }
        return false;
    }
}
