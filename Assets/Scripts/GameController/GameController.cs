using UnityEngine;
using TMPro;
using System.Collections; // Required for coroutines

public class GameController : MonoBehaviour
{
    public int score = 0;
    public static GameController Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject bossPrefab; // Ensure bossPrefab is declared here
    [SerializeField] private Transform bossSpawnPoint;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private EnemySpawner_Olho enemySpawner_;
    private bool bossSpawned = false;
    [SerializeField] private float bossSpawnDelay = 2f; // Time to wait before spawning the boss

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();

        if (score >= 500 && !bossSpawned)
        {
            StartCoroutine(SpawnBossCoroutine()); // Use a coroutine to handle delay
        }
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    private IEnumerator SpawnBossCoroutine()
    {
        bossSpawned = true;

        // Stop normal enemy spawning
        if (enemySpawner != null)
        {
            enemySpawner.StopSpawning();
            enemySpawner_.StopSpawning();
        }

        // Wait for the specified delay before spawning the boss
        yield return new WaitForSeconds(bossSpawnDelay);

        // Spawn the boss
        if (bossPrefab != null)
        {
            Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Boss Prefab is not assigned in the GameController!");
        }
    }

    // Call this method when the boss is defeated
    public void OnBossDefeated()
    {
        bossSpawned = false;

        // Resume normal enemy spawning
        if (enemySpawner != null)
        {
            enemySpawner.StartSpawning();
             enemySpawner_.StartSpawning();
        }
    }
}