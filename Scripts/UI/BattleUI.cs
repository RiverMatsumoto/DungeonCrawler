using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public GameObject commandButtons;
    public BackButton backButton;
    // TODO CHANGE COMPLETELY TO REMEMBER THE LAST BUTTON PRESSED FROM PLAYER
    public Button attackButton;
    public Button backButtonComponent;

    public void stopSelectingEntity()
    {
        commandButtons.SetActive(true);
        backButton.gameObject.SetActive(false);
        backButtonComponent.enabled = false;
        attackButton.Select();
    }

    public void selectEntity()
    {
        commandButtons.SetActive(false);
        backButton.gameObject.SetActive(true);
        backButtonComponent.enabled = true;
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
