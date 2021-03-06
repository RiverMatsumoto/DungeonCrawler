using UnityEngine;

public class Medica : Usable
{
    public override string name { get; protected set; }

    public Medica()
    {
        name = "Medica";
    }

    public override void Use()
    {
        // select player
        // listen for player selected event
        PlayerSelectSystem.Instance.StartSelectPlayer();
        PlayerSelectSystem.Instance._selectPlayer += OnSelectPlayer;
        PlayerSelectSystem.Instance._cancelSelectPlayer += OnSelectPlayerCancel;
    }

    public void useInMenu()
    {

    }

    public void OnSelectPlayer(BattleEntity e)
    {
        DeregisterPlayerSelectEvents();
        // use the medica on the entity
        // add 50 health to that player
        Debug.Log("Gave 50 HP to player");
        e.characterData.Health += 50;
    }

    public void OnSelectPlayerCancel()
    {
        DeregisterPlayerSelectEvents();
    }

    private void DeregisterPlayerSelectEvents()
    {
        PlayerSelectSystem.Instance._selectPlayer -= OnSelectPlayer;
        PlayerSelectSystem.Instance._cancelSelectPlayer -= OnSelectPlayerCancel;
    }
}
