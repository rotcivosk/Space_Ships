using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Image selectionIcon; // O ícone de seleção que se move
    [SerializeField] private RectTransform[] menuOptions; // Opções do menu (Start, Exit)

    private int currentIndex = 0; // Index da opção selecionada

    void Start()
    {
        // Garante que o ícone comece na primeira opção (Start Game)
        UpdateSelectionIconPosition();
    }

    void Update()
    {
        // Detecta a navegação para cima ou para baixo
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            ToggleSelection();
        }

        // Detecta a tecla de seleção (espaço)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectOption();
        }
    }

    // Alterna entre as duas opções do menu
    void ToggleSelection()
    {
        currentIndex = (currentIndex == 0) ? 1 : 0; // Se for 0, muda para 1; se for 1, muda para 0
        UpdateSelectionIconPosition();
    }

    // Atualiza a posição do ícone de seleção
    void UpdateSelectionIconPosition()
{
    float offsetX = -33f; // Valor negativo move para a esquerda

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
                StartGame();
                break;
            case 1:
                ExitGame();
                break;
            default:
                Debug.LogError("Opção inválida no menu.");
                break;
        }
    }

    // Iniciar o jogo
    void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Troque "GameScene" pelo nome da sua cena do jogo
    }

    // Sair do jogo
    void ExitGame()
    {
        Application.Quit();
        
#if UNITY_EDITOR
        // Para funcionar no editor
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
