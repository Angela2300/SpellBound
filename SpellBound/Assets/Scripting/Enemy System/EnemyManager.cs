using UnityEngine; 
using System.Collections.Generic; 
public class EnemyManager : MonoBehaviour 
{
   
    public static Dictionary<string, EnemyData> enemyDatabase = new Dictionary<string, EnemyData>();

    void Awake()
    {
        LoadCSV();
    }

    void LoadCSV()
    {
        TextAsset csvData = Resources.Load<TextAsset>("Enemies");
        if (csvData == null)
        {
            Debug.LogError("Could not find Enemies.csv in Resources folder!");
            return;
        }

        string[] lines = csvData.text.Split('\n');

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;
            string[] row = lines[i].Split(',');

            EnemyData data = new EnemyData
            {
                enemyID = row[0],
                displayName = row[1],
                role = row[2],
                health = float.Parse(row[3]),
                damageHearts = float.Parse(row[4]),
                damageLives = float.Parse(row[5]),
                moveSpeedTier = row[6],
                moveSpeedValue = row[7],
                rangeTier = row[8],
                followsPlayer = bool.Parse(row[9]),
                weaponId = row[10],
                meatDropAmt = row[11]
            };
            enemyDatabase[data.enemyID] = data;
        }
    }
}