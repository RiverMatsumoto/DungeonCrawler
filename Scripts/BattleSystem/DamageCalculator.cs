using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculator : MonoBehaviour
{

    public static float calculateAttack(CharacterData attacker, CharacterData defender, float[] multipliers)
    {
        float finalDamageResult = 10;

        finalDamageResult = (int)finalDamageResult;
        return finalDamageResult;
    }
}
