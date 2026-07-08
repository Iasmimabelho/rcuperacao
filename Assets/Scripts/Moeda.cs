using UnityEngine;
using TMPro;

public class Moeda : MonoBehaviour
{
    public static int pontos = 0;
    private TextMeshProUGUI textoPlacar;

    [Header("Configuração de Partículas")]
    // 1. ISSO FOI ADICIONADO: Campo para receber o Prefab da sua partícula
    public GameObject particulaPrefab;

    void Start()
    {
        GameObject objetoTexto = GameObject.Find("Text (TMP)");

        if (objetoTexto != null)
        {
            textoPlacar = objetoTexto.GetComponent<TextMeshProUGUI>();
        }

        AtualizarTextoInterface();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pontos++;
            
            AtualizarTextoInterface();

            Debug.Log("Pontos: " + pontos);
            
            // 2. ISSO FOI ADICIONADO: Cria a explosão de mini-moedas na posição atual da moeda
            if (particulaPrefab != null)
            {
                Instantiate(particulaPrefab, transform.position, Quaternion.identity);
            }
            
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