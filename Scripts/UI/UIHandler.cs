using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Canvas overworldHud;
    public Canvas battleHud;
    public Button battleFirstSelectedButton;
    private void Start()
    {
        // overworldHud.gameObject.SetActive(true);
        // battleHud.gameObject.SetActive(false);
        overworldHud.enabled = true;
        battleHud.enabled = false;
    }

    public void OnBattleStarted()
    {
        overworldHud.enabled = false;
        battleHud.enabled = true;
        battleFirstSelectedButton.Select();
        // overworldHud.gameObject.SetActive(false);
        // battleHud.gameObject.SetActive(true);
    }

    public void OnBattleEnded()
    {
        overworldHud.enabled = true;
        battleHud.enabled = false;
        // overworldHud.gameObject.SetActive(true);
        // battleHud.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        BattleEventHandler.battleStarted += OnBattleStarted;
        BattleEventHandler.battleEnded += OnBattleEnded;
    }

    private void OnDisable()
    {
        BattleEventHandler.battleStarted -= OnBattleStarted;
        BattleEventHandler.battleEnded -= OnBattleEnded;
    }
}
