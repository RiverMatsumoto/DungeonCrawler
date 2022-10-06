using UnityEngine;

[CreateAssetMenu(fileName = "EmptyClass", menuName = "ScriptableObject/ClassType/EmptyClass")]
public class EmptyClass : ClassType
{
    [SerializeField]
    public override ClassTypeEnum type { get; set; }

    public override int GetBaseMaxHealth(int level)
    {
        return 0;
    }

    public override int GetBaseMaxTalentPoints(int level)
    {
        return 0;
    }

    public override int GetBaseStrength(int level)
    {
        return 0;
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

    public override void InitializeSpecialCharacterTraits(CharacterData data)
    {
        
    }
}
