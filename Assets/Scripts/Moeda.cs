using UnityEngine;
using TMPro;

public class Moeda : MonoBehaviour
{
    public static int pontos = 0;
    private TextMeshProUGUI textoPlacar;

    void Start()
    {
        // Procura na cena pelo objeto exato chamado "Text (TMP)"
        GameObject objetoTexto = GameObject.Find("Text (TMP)");

        if (objetoTexto != null)
        {
            // Pega o componente de texto de dentro dele
            textoPlacar = objetoTexto.GetComponent<TextMeshProUGUI>();
        }

        // Atualiza o texto no início do jogo
        AtualizarTextoInterface();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pontos++;
            
            AtualizarTextoInterface();

            Debug.Log("Pontos: " + pontos);
            
            Destroy(gameObject);
        }
    }

    void AtualizarTextoInterface()
    {
        if (textoPlacar != null)
        {
            textoPlacar.text = "Moedas: " + pontos;
        }
    }
}