using UnityEngine;
using System.IO;

public class GeradorDeSprite : MonoBehaviour
{
    // Arraste o frame_0 para cá no Inspector
    public Sprite spriteDaMoeda; 

    [ContextMenu("Salvar Moeda Unica")]
    void SalvarMoeda()
    {
        if (spriteDaMoeda == null) return;

        Texture2D texturaOriginal = spriteDaMoeda.texture;
        Rect r = spriteDaMoeda.rect;
        
        // Cria uma nova textura apenas com o tamanho do pedaço cortado
        Texture2D novaTextura = new Texture2D((int)r.width, (int)r.height);
        Color[] pixels = texturaOriginal.GetPixels((int)r.x, (int)r.y, (int)r.width, (int)r.height);
        
        novaTextura.SetPixels(pixels);
        novaTextura.Apply();

        // Transforma em arquivo PNG real
        byte[] bytes = novaTextura.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/Moeda_Unica.png", bytes);
        
        Debug.Log("Sucesso! O arquivo Moeda_Unica.png foi criado na sua pasta Assets!");
    }
}