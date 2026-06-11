using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string enemyID; // Set this in the Inspector
    private EnemyData stats;

    void Start()
    {
        if (EnemyManager.enemyDatabase.TryGetValue(enemyID, out stats))
        {
            // Apply stats from the DTO to the GameObject
            InitializeEnemy(stats);
        }
    }

    void InitializeEnemy(EnemyData data)
    {
        // Example: Using the parsed data
        gameObject.name = data.displayName;
        float health = data.health;
        bool shouldFollow = data.followsPlayer;

        Debug.Log($"Enemy {data.displayName} initialized with {health} HP.");
    }
}