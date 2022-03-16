using UnityEngine;

public class AttackButton : MonoBehaviour
{
    private PlayerSelectListener selectListener;
    public void selectTarget()
    {
        BattleSystem.Instance.StartSelectingEntity(true);
    }

    public void _OnSelectPlayer(BattleEntity target)
    {
        Debug.Log("Added the attack command to the intended actions list");
        BattleEntity attacker = BattleSystem.Instance.currentEntity;
        BattleCommand cmd = new AttackCommand(attacker, target);
        BattleSystem.Instance.AddIntendedBattleCommand(cmd);
    }


    private void Start()
    {
        selectListener = new PlayerSelectListener(_OnSelectPlayer);
    }
}