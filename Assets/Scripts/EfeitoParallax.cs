using UnityEngine;
using UnityEngine.UI;

public class EfeitoParallax : MonoBehaviour
{
    [SerializeField] private Image fundo;
    [SerializeField] private float velocidade;

    private float comprimentoImagem;

    private void Start()
    {
        // Converte a largura da imagem para unidades do mundo (world units)
        comprimentoImagem = fundo.rectTransform.rect.width;
    }

    private void Update()
    {
        transform.position += Vector3.left * velocidade * Time.deltaTime;

        if (transform.localPosition.x <= -comprimentoImagem)
        {
            // Reposiciona a imagem para a direita da tela
            transform.localPosition = new Vector3(transform.localPosition.x + comprimentoImagem * 2, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
