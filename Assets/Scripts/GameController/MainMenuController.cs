using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Image selectionIcon; // The selection icon that moves
    [SerializeField] private RectTransform[] menuOptions; // Menu options (Start, Exit)

    private int currentIndex = 0; // Index of the selected option

    void Start()
    {
        // Ensure the icon starts at the first option (Start Game)
        UpdateSelectionIconPosition();
    }

    void Update()
    {
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
        float offsetX = -33f; // Negative value moves to the left

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
                StartGame();
                break;
            case 1:
                ExitGame();
                break;
            default:
                Debug.LogError("Invalid menu option.");
                break;
        }
    }

    // Start the game
    void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace "GameScene" with your game's scene name
    }

    // Exit the game
    void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        // To make it work in the editor
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
