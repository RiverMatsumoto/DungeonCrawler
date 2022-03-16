using System;

public class PlayerSelectListener
{
    public Action<BattleEntity> onSelect { get; set; }
    public PlayerSelectListener(Action<BattleEntity> onSelect)
    {
        this.onSelect = onSelect;
        EnableListener();
    }
    public void OnSelectPlayer(BattleEntity entity)
    {
        onSelect.Invoke(entity);
        StopListeningToSelectPlayer();
    }

    public void OnSelectPlayerCancel()
    {
        StopListeningToSelectPlayer();
    }

    public void ListenToSelectPlayer()
    {
        PlayerSelectSystem.Instance._selectPlayer += OnSelectPlayer;
        PlayerSelectSystem.Instance._cancelSelectPlayer += OnSelectPlayerCancel;
    }

    public void StopListeningToSelectPlayer()
    {
        PlayerSelectSystem.Instance._selectPlayer -= OnSelectPlayer;
        PlayerSelectSystem.Instance._cancelSelectPlayer -= OnSelectPlayerCancel;
    }

    public void DisableListener() => PlayerSelectSystem.Instance._startSelectPlayer -= ListenToSelectPlayer;

    public void EnableListener() => PlayerSelectSystem.Instance._startSelectPlayer += ListenToSelectPlayer;
}
