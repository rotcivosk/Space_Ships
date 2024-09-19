using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_Olho : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private Transform[] spawnPoints; // Positions where enemies can spawn
    [SerializeField] private MovementType[] movementTypes; // Different movement patterns
    private float nextSpawn;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // Get an enemy from the pool
        GameObject enemy = EnemyPool_Olho.Instance.GetObject();

        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        enemy.transform.position = spawnPoint.position;
        enemy.transform.rotation = spawnPoint.rotation;

        // Assign a movement pattern
        MovementType movementType = movementTypes[Random.Range(0, movementTypes.Length)];
        AssignMovementPattern(enemy, movementType);
    }

    void AssignMovementPattern(GameObject enemy, MovementType movementType)
    {
        // Remove existing movement scripts
        EnemyMovement existingMovement = enemy.GetComponent<EnemyMovement>();
        if (existingMovement != null)
        {
            Destroy(existingMovement);
        }

        // Add the new movement script based on the movement type
        switch (movementType)
        {
            case MovementType.Straight:
                enemy.AddComponent<StraightMovement>();
                break;
            case MovementType.Zigzag:
                enemy.AddComponent<ZigzagMovement>();
                break;
            // Add cases for other movement types
            default:
                enemy.AddComponent<StraightMovement>(); // Default movement
                break;
        }
    }
}