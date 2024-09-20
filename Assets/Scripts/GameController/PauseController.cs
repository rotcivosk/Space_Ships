using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private Image selectionIcon; // O ícone de seleção que se move
    [SerializeField] private RectTransform[] menuOptions; // Opções do menu (Resume, Exit)
    
    [SerializeField] private GameObject pauseMenuUI;

    private bool isPaused = false;
    private int currentIndex = 0; // Index da opção selecionada

    void Update()
    {
        // Detecta a tecla ESC para pausar ou despausar
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }

        // Se o jogo estiver pausado, permite navegação no menu
        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                ToggleSelection(); // Alterna entre as opções
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SelectOption(); // Seleciona a opção atual
            }
        }
    }

    // Alterna entre as opções do menu
    void ToggleSelection()
    {
        currentIndex = (currentIndex == 0) ? 1 : 0; // Alterna entre Resume (0) e Exit (1)
        UpdateSelectionIconPosition();
    }

    // Atualiza a posição do ícone de seleção
    void UpdateSelectionIconPosition()
    {
        // Definir o deslocamento no eixo X para mover o ícone para a esquerda
        float offsetX = -38f; // Ajuste o valor conforme necessário

        // Obter a posição da opção atual
        Vector3 newPosition = menuOptions[currentIndex].position;

        // Aplicar o deslocamento no eixo X
        newPosition.x += offsetX;

        // Atualizar a posição do ícone de seleção
        selectionIcon.rectTransform.position = newPosition;
    }

    // Executa a ação da opção selecionada
    void SelectOption()
    {
        switch (currentIndex)
        {
            case 0:
                ResumeGame(); // Retomar o jogo
                break;
            case 1:
                ExitGame(); // Sair para o menu principal
                break;
            default:
                Debug.LogError("Opção inválida no menu de pausa.");
                break;
        }
    }

    // Retoma o jogo
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Retomar o tempo
        isPaused = false;
    }

    // Pausa o jogo
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pausar o tempo
        isPaused = true;

        // Atualiza a posição do ícone de seleção quando o menu é ativado
        UpdateSelectionIconPosition();
    }

    // Sai do jogo e vai para o menu principal
    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}