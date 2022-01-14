using Sirenix.OdinInspector;

public class PartyDataStruct
{

    [TableList(ShowIndexLabels = true)]
    public DataForInspector[] party;

    [Button("New Default Party")]
    public void NewDefaultParty()
    {
        party = new DataForInspector[6];
        for (var i = 0; i < party.Length; i++)
        {
            party[i] = new DataForInspector(EnemyType.Null, false);
        }
    }

    [System.Serializable]
    public class DataForInspector
    {
        public EnemyType enemyType;
        public bool isBackRow;
        public DataForInspector(EnemyType enemyType, bool isBackRow)
        {
            this.enemyType = enemyType;
            this.isBackRow = isBackRow;
        }
    }
}
