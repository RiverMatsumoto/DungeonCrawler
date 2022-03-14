using UnityEngine;

public class PlayerSelectSystem : MonoBehaviour
{
    public static PlayerSelectSystem instance;
    public OverworldData data;
    // TODO implement remembering last player selected
    // Selects a player and casts an event
    public delegate void startSelectPlayerEvent();
    public static event startSelectPlayerEvent startSelectPlayer;
    public delegate void selectPlayerCancelEvent();
    public static event selectPlayerCancelEvent selectPlayerCancel;
    public delegate void selectPlayerEvent(BattleEntity e);
    public static event selectPlayerEvent selectPlayer;

    public void StartSelectPlayer()
    {
        if (data.inBattle)
        {
            // put cursor on party in battle
            Debug.Log("put cursor on party in battle");
            BattleSystem.Instance.SelectPlayer();
        }
        else
        {
            // open up selecting menu
            Debug.Log("put cursor on party in menu");
        }
    }

    public void SelectPlayerCancel()
    {
        selectPlayerCancel.Invoke();
    }

    public void SelectPlayer(BattleEntity e)
    {
        selectPlayer.Invoke(e);
    }

    private void Awake()
    {
        if (instance != null || instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}