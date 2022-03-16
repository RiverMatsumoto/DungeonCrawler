/// <summary>
/// Select Listeners should:
/// 1. Listen for SelectPlayer event
/// 2. Stop Listening to SelectPlayer on SelectPlayerCancel
/// 3. React to SelectPlayer event
/// </summary>
public interface ISelectListener
{
    void ListenToSelectPlayer();
    void OnSelectPlayer(BattleEntity e);
    void OnSelectPlayerCancel();
}
