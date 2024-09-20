using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{

    private bool isPaused = false;
    [SerializeField] private GameObject pauseMenuUI;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }

    }

public void ResumeGame(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume time
        isPaused = false;
}

public void PauseGame(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause time
        isPaused = true;

}
public void ExitGame(){
    Time.timeScale = 1f;
    SceneManager.LoadScene("MainMenu");
    
}

}
