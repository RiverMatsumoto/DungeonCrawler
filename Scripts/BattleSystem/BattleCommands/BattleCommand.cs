using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleCommand
{
    public BattleEntity battleEntity;
    public BattleEntity target;
    public List<float> physicalMultipliers;
    public List<float> elementalMultipliers;

    public abstract void executeCommand();
}