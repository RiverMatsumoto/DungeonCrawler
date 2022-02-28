
public class BattleEventHandler
{
    public delegate void battleStartedEvent();
    public static event battleStartedEvent battleStarted;
    public delegate void battleEndedEvent();
    public static event battleEndedEvent battleEnded;
    public delegate void turnStartedEvent();
    public static event turnStartedEvent turnStarted;
    public delegate void turnEndedEvent();
    public static event turnEndedEvent turnEnded;
    public delegate void battlePhaseEvent();
    public static event battlePhaseEvent battlePhase;




    public static void broadcastBattleStarted() => battleStarted.Invoke();
    public static void broadcastBattleEnded() => battleEnded.Invoke();
    public static void broadcastTurnStarted() => turnStarted.Invoke();
    public static void broadcastTurnEnded() => turnEnded.Invoke();
    public static void broadcastBattlePhase() => battlePhase.Invoke();
}
