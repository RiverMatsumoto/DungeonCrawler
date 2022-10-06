using UnityEngine;

[CreateAssetMenu(fileName = "SamuraiClass", menuName = "ScriptableObject/ClassType/Samurai")]
public class SamuraiClass : ClassType
{
    [SerializeField]
    public override ClassTypeEnum type { get; set; }

    /// <summary>
    /// Gets base max health with formula:
    /// f(x) = 0.01x^2 + 3.1x + 24
    /// Health ranges from 24 to 434
    /// </summary>
    /// <param name="level">Level of the character</param>
    /// <returns>An int max health value for the specified class</returns>
    public override int GetBaseMaxHealth(int level)
    {
        return Mathf.RoundToInt((0.01f*level*level) + (3.1f*level) + 18);
    }

    /// <summary>
    /// Gets base max talent points:
    /// f(x) = 0.01x^2 + 2.3x + 18
    /// </summary>
    /// <param name="level">Level of character</param>
    /// <returns>Integer value of talent points</returns>
    public override int GetBaseMaxTalentPoints(int level)
    {
        return Mathf.RoundToInt((0.01f*level*level) + (2.3f*level) + 18);
    }

    /// <summary>
    /// Gets base strength with formula:
    /// f(x) = 2.67x + 7
    /// </summary>
    /// <param name="level">Level of character</param>
    /// <returns>The base strength</returns>
    public override int GetBaseStrength(int level)
    {
        return Mathf.RoundToInt((2.67f * level) + 7);
    }

    /// <summary>
    /// Gets base vitality with formula:
    /// f(x) = 1.9x + 4
    /// </summary>
    /// <param name="level">Level of entity</param>
    /// <returns>Integer value of the vitality</returns>
    public override int GetBaseVitality(int level)
    {
        return Mathf.RoundToInt((1.9f * level) + 4);
    }

    /// <summary>
    /// Gets base wisdom with formula:
    /// f(x) = 1.62x + 4
    /// </summary>
    /// <param name="level">Level of entity</param>
    /// <returns>Integer value of wisdom</returns>
    public override int GetBaseWisdom(int level)
    {
        return Mathf.RoundToInt((1.62f * level) + 3);
    }

    /// <summary>
    /// Gets base agility with formula:
    /// f(x) = 2.58x + 7
    /// </summary>
    /// <param name="level">Level of character</param>
    /// <returns>Integer value of agility</returns>
    public override int GetBaseAgility(int level)
    {
        return Mathf.RoundToInt((2.58f * level) + 7);
    }

    /// <summary>
    /// Gets base tech with formula: 
    /// f(x) = 1.3x + 2
    /// </summary>
    /// <param name="level">Level of character</param>
    /// <returns>Integer value of base tech</returns>
    public override int GetBaseTech(int level)
    {
        return Mathf.RoundToInt((1.3f * level) + 2);
    }

    /// <summary>
    /// Gets base luck with formula: 
    /// f(x) = 2.1x + 4
    /// </summary>
    /// <param name="level">Level of character</param>
    /// <returns>Integer value of luck</returns>
    public override int GetBaseLuck(int level)
    {
        return Mathf.RoundToInt((2.1f * level) + 4);
    }

    public override void InitializeSpecialCharacterTraits(CharacterData data)
    {
        // TODO Samurai can wield 2 weapons
    }
}
