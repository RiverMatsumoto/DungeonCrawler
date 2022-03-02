using UnityEngine;

public class PlayerSelectSystem : MonoBehaviour
{
    // Selects a player and casts an event
    public delegate void selectPlayerEvent(BattleEntity e);
    public static event selectPlayerEvent selectPlayer;
    public delegate void selectPlayerCancelEvent();
    public static event selectPlayerCancelEvent selectPlayerCancel;

}
