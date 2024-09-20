using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenuController : MonoBehaviour
{
    [SerializeField] private Image selectionIcon; // The selection icon that moves
    [SerializeField] private RectTransform[] menuOptions; // Menu options (Restart, Exit)

    private int currentIndex = 0; // Index of the selected option

    void OnEnable()
    {
        // Ensure the icon starts at the first option (Restart Game)
        currentIndex = 0;
        UpdateSelectionIconPosition();
    }

    void Update()
    {
        // Only process input if the menu is active
        if (!gameObject.activeInHierarchy)
            return;

        // Detect navigation up or down
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            ToggleSelection();
        }

        // Detect the selection key (space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectOption();
        }
    }

    // Toggle between the two menu options
    void ToggleSelection()
    {
        currentIndex = (currentIndex == 0) ? 1 : 0; // Switch between 0 and 1
        UpdateSelectionIconPosition();
    }

    // Update the position of the selection icon
    void UpdateSelectionIconPosition()
    {
        float offsetX = -40f; // Negative value moves to the left

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
                RestartGame();
                break;
            case 1:
                ExitToMainMenu();
                break;
            default:
                Debug.LogError("Invalid menu option.");
                break;
        }
    }

    private void RestartGame()
    {
        // Reload the current scene
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ExitToMainMenu()
    {
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene("MainMenu");
    }
}