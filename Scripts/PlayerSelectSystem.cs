using UnityEngine;

public class PlayerSelectSystem : MonoBehaviour
{
    public static PlayerSelectSystem Instance;
    public OverworldData data;
    // TODO implement remembering last player selected
    // Selects a player and casts an event
    public delegate void startSelectPlayerEvent();
    public event startSelectPlayerEvent _startSelectPlayer;
    public delegate void selectPlayerEndEvent();
    public event selectPlayerEndEvent _cancelSelectPlayer;
    public delegate void selectPlayerEvent(BattleEntity e);
    public event selectPlayerEvent _selectPlayer;

    public void StartSelectPlayer()
    {
        if (data.inBattle)
        {
            // put cursor on party in battle
            Debug.Log("StartSelectPlayer called");
            _startSelectPlayer?.Invoke();
        }
        else
        {
            // open up selecting menu
            Debug.Log("put cursor on party in menu");
        }
    }

    public void SelectPlayerCancel()
    {
        _cancelSelectPlayer?.Invoke();
    }

    public void SelectPlayer(BattleEntity e)
    {
        Debug.Log("got here");
        _selectPlayer?.Invoke(e);
    }

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
}