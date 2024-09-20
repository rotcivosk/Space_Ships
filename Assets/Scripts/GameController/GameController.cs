using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public int score = 0;
    public static GameController Instance;
    [SerializeField] private GameObject endLevelMenuUI;
    [SerializeField] private TextMeshProUGUI scoreText;

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
