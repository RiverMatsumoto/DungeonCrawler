using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurnCommand
{
    CharacterData battleEntity;
    CharacterData target;
    List<float> physicalMultipliers;
    List<float> elementalMultipliers;
}
