using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public GameObject commandButtons;
    // TODO CHANGE COMPLETELY TO REMEMBER THE LAST BUTTON PRESSED FROM PLAYER
    public Button attackButton;

    public void stopSelectingEntity()
    {
        commandButtons.SetActive(true);
        attackButton.Select();
    }

    public void selectEntity()
    {
        commandButtons.SetActive(false);
    }

    private void _onSelectEntity(BattleEntity e) => stopSelectingEntity();

    private void OnEnable()
    {
        PlayerSelectSystem.Instance._startSelectPlayer += selectEntity;
        PlayerSelectSystem.Instance._cancelSelectPlayer += stopSelectingEntity;
        PlayerSelectSystem.Instance._selectPlayer += _onSelectEntity;
        BattleEventHandler.battleStarted += stopSelectingEntity;
    }

    private void OnDisable()
    {
        PlayerSelectSystem.Instance._startSelectPlayer -= selectEntity;
        PlayerSelectSystem.Instance._cancelSelectPlayer -= stopSelectingEntity;
        PlayerSelectSystem.Instance._selectPlayer -= _onSelectEntity;
        BattleEventHandler.battleStarted -= stopSelectingEntity;
    }
}
