using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private Image selectionIcon; // The selection icon that moves
    [SerializeField] private RectTransform[] menuOptions; // Menu options (Resume, Exit)
    [SerializeField] private GameObject pauseMenuUI;

    private bool isPaused = false;
    private int currentIndex = 0; // Index of the selected option

    void Update()
    {
        // Detect the ESC key to pause or resume
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }

        // If the game is paused, allow menu navigation
        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                ToggleSelection(); // Toggle between options
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SelectOption(); // Select the current option
            }
        }
    }

    // Toggle between menu options
    void ToggleSelection()
    {
        currentIndex = (currentIndex == 0) ? 1 : 0; // Switch between Resume (0) and Exit (1)
        UpdateSelectionIconPosition();
    }

    // Update the position of the selection icon
    void UpdateSelectionIconPosition()
    {
        float offsetX = -38f; // Adjust the value as needed

        Vector3 newPosition = menuOptions[currentIndex].position;

        // Apply the offset on the X-axis
        newPosition.x += offsetX;

        // Update the position of the selection icon
        selectionIcon.rectTransform.position = newPosition;
    }

    // Execute the action of the selected option
    void SelectOption()
    {
        switch (currentIndex)
        {
            case 0:
                ResumeGame(); // Resume the game
                break;
            case 1:
                ExitGame(); // Exit to the main menu
                break;
            default:
                Debug.LogError("Invalid option in the pause menu.");
                break;
        }
    }

    // Resume the game
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume time
        isPaused = false;
    }

    // Pause the game
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause time
        isPaused = true;

        // Update the position of the selection icon when the menu is activated
        UpdateSelectionIconPosition();
    }

    // Exit the game and go to the main menu
    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
