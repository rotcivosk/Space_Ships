using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public int score = 0;
    public static GameController Instance;
    [SerializeField] private GameObject endLevelMenuUI;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private EnemySpawner enemySpawner1;
        [SerializeField] private EnemySpawner enemySpawner2;
    private bool bossSpawned = false;
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
                if (score >= 1000 && !bossSpawned)
        {
            SpawnBoss();
        }
    }
     private void SpawnBoss()
    {
        bossSpawned = true;

        // Stop normal enemy spawning
        if (enemySpawner1 != null)
        {
            enemySpawner1.StopSpawning();
        }

        // Spawn the boss
        Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
    }
    // Call this method when the boss is defeated
    public void OnBossDefeated()
    {
        // Resume normal enemy spawning
        if (enemySpawner != null)
        {
            enemySpawner.StartSpawning();
        }
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        // Activate the end level menu
        endLevelMenuUI.SetActive(true);
        // Time.timeScale = 0f; // Optional: Pause the game
    }
}
