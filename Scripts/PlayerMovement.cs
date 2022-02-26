using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

public class PlayerMovement : SerializedMonoBehaviour, IOccupiesTile
{
    #region Variables
    public Vector2Int localForward { get; set; }
    public Vector2Int localRight;
    public Vector2Int localBack;
    public Vector2Int localLeft;
    public Vector2Int mapPosition { get; set; }
    public MapHandler mapHandler;
    public OverworldData overworldData;
    public float MOVE_TIME = 0.3F;
    public float MOVE_COOLDOWN_TIME = 0.02F;
    public float MOVE_DISTANCE = 5;
    public PlayerControls controls;
    public PlayerInput pControls;
    private Vector2 input;
    private float turnInput;
    bool isActionable;
    #endregion

    void Awake()
    {
        // Initialize everything
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
        if (overworldData.inBattle) return;
        // read input and poll for movement. Moving has priority
        // I'm using polling because unity's input actions don't constantly read input.
        // input = controls.Player.Movement.ReadValue<Vector2>();
        input = pControls.actions["Movement"].ReadValue<Vector2>();
        attemptMove(input);

        // turnInput = controls.Player.Movement.ReadValue<float>();
        turnInput = pControls.actions["Turn"].ReadValue<float>();
        attemptTurn(turnInput);

    }


    #region Movement: turning the player
    /// <summary>
    /// Called in the fixed update loop. Reads the controller input and moves
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
            turnLocalFacingRight();
            StartCoroutine(turnPlayer(transform.right));
        }
        else if (turnInput < -0.5)
        {
            turnLocalFacingLeft();
            StartCoroutine(turnPlayer(-transform.right));
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

        // broadcast event that player turned
        // TODO MovementEventHandler.playerTurned(MovementEventHandler.quaternionTo2D(endPoint), localForward);
        // playerTurnedEvent.raise();
        broadcastPlayerTurned(localForward);
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
    private void turnLocalFacingLeft()
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
    #endregion

    #region Movement: moving between tiles
    ///  <summary>
    ///  Called in the fixed update loop. Uses the already read input values
    ///  and moves the player in the direction they press.
    /// </summary>
    /// <param name="userInput">
    /// A Vector2 variable representing the user input with a range from 0-1 for the x and y axis.
    /// </param>
    void attemptMove(Vector2 userInput)
    {
        if (!isActionable) { return; }

        if (userInput.y > 0.5 && mapHandler.currentMap.isValidMove(localForward + mapPosition)) // move forwards
        {
            mapHandler.currentMap.placeCharacter(mapPosition, localForward, this);
            StartCoroutine(movePlayer(localForward));
        }
        else if (userInput.y < -0.5 && mapHandler.currentMap.isValidMove(localBack + mapPosition)) // move backwards
        {
            mapHandler.currentMap.placeCharacter(mapPosition, localBack, this);
            StartCoroutine(movePlayer(localBack));
        }
        else if (userInput.x > 0.5 && mapHandler.currentMap.isValidMove(localRight + mapPosition)) // move right
        {
            mapHandler.currentMap.placeCharacter(mapPosition, localRight, this);
            StartCoroutine(movePlayer(localRight));
        }
        else if (userInput.x < -0.5 && mapHandler.currentMap.isValidMove(localLeft + mapPosition)) // move left
        {
            mapHandler.currentMap.placeCharacter(mapPosition, localLeft, this);
            StartCoroutine(movePlayer(localLeft));
        }
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
        // mapHandler.currentMap.placeCharacter(mapPosition, direction, this);
        mapPosition += direction;
        // playerMoveStartEvent.raise();
        broadcastPlayerMoved(mapPosition);

        Vector3 v3direction = new Vector3(direction.x, 0, direction.y);
        Vector3 startPoint = transform.localPosition;
        Vector3 endPoint = transform.localPosition + (v3direction * MOVE_DISTANCE);
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
        // TODO MovementEventHandler.playerMoveEnded();
        broadcastPlayerMovedEnded();
        isActionable = true;
    }

    #endregion

    #region Map related player placement
    /// <summary>
    /// Places the player in a certain location with certain facing direction using the position and direction passed through.
    /// Position should be in the map range and facing direction should be a cardinal direction.
    /// </summary>
    /// <param name="position">The position the player is being placed in</param>
    /// <param name="facingDir"></param>
    public void placePlayer(Vector2Int position, Vector2Int facingDir)
    {
        faceDirection(facingDir);
        mapPosition = position;

        Debug.Log(mapPosition);
        Vector3 newPos = new Vector3(); // adjust the physical transform to match the coordinates on the map
        newPos.x = position.x * MOVE_DISTANCE;
        newPos.z = position.y * MOVE_DISTANCE;
        transform.position = newPos;

        broadcastPlayerMoved(mapPosition);
    }

    private void updateOverworldData()
    {
        overworldData.playerPosition = mapPosition;
        overworldData.playerFacingDir = localForward;
    }

    private void faceDirection(Vector2Int newForward)
    {
        // not gonna lie this is just a magic formula
        localForward = newForward;
        localBack = newForward * -1;
        localLeft.x = localBack.y;
        localLeft.y = localBack.x;
        localRight.x = localForward.y;
        localRight.y = localForward.x;
        Vector3 endRotation = new Vector3(newForward.x, 0, newForward.y);
        Quaternion endDir = transform.localRotation;
        endDir.SetLookRotation(endRotation);
        transform.localRotation = endDir;

        // TODO MovementEventHandler.playerTurned(MovementEventHandler.quaternionTo2D(endDir), localForward);
        broadcastPlayerTurned(localForward);
    }
    #endregion

    private void broadcastPlayerMoved(Vector2Int position)
    {
        updateOverworldData();
        MovementEventHandler.broadcastPlayerMoved(position);
    }
    private void broadcastPlayerMovedEnded()
    {
        updateOverworldData();
        MovementEventHandler.broadcastPlayerMoveEnded();
    }
    private void broadcastPlayerTurned(Vector2Int direction)
    {
        updateOverworldData();
        MovementEventHandler.broadcastPlayerTurned(direction);
    }
}