using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
        void Start()
    {
        Time.timeScale = 1f;
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame(){

        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }


}
