using UnityEngine;

public class DestruirParticula : MonoBehaviour
{
    void Start()
    {
        // Deleta o objeto da partícula do jogo após 1 segundo 
        // (tempo suficiente para as moedinhas explodirem e sumirem)
        Destroy(gameObject, 1f);
    }
}