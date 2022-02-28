using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{
    private const int ATTACK = 5;
    public override string name { get; protected set; }
    public override AttackType type { get; protected set; }

    public Knife() : base(ATTACK)
    {
        name = "Knife";
    }
}
