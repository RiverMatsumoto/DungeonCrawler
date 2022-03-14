using UnityEngine;

[CreateAssetMenu(fileName = "SamuraiClass", menuName = "ScriptableObject/ClassType/Samurai")]
public class SamuraiClass : ClassType
{
    [SerializeField]
    public override ClassTypeEnum type { get; set; }

    /// <summary>
    /// Gets BaseMaxHealth with formula:
    /// f(x) = ((x^1.4)/2) + ln(x) + 26
    /// </summary>
    /// <param name="level">Level of the character</param>
    /// <returns>An int max health value for the specified class</returns>
    public override int GetBaseMaxHealth(int level)
    {
        return (int)Mathf.Round(Mathf.Pow(level, 1.4F) + Mathf.Log(level) + 26);
    }

    public override int GetBaseMaxTalentPoints(int level)
    {
        return 0;
    }

    /// <summary>
    /// Gets base strength with formula:
    /// (0.5x^0.7) + (0.4x^1.08) + 8
    /// </summary>
    /// <param name="level">Leve of character</param>
    /// <returns>The base strength</returns>
    public override int GetBaseStrength(int level)
    {
        return (int)Mathf.Round(0.8F * level);
    }
    public override int GetBaseVitality(int level)
    {
        return 0;
    }
    public override int GetBaseWisdom(int level)
    {
        return 0;
    }
    public override int GetBaseAgility(int level)
    {
        return 0;
    }
    public override int GetBaseTech(int level)
    {
        return 0;
    }
    public override int GetBaseLuck(int level)
    {
        return 0;
    }
}
