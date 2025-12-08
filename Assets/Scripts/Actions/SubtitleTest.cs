using UnityEngine;

public class SubtitleTest : MonoBehaviour
{
    void Start()
    {
        // apagar futuramente
        SubtitleManager manager = FindObjectOfType<SubtitleManager>();
        
        if (manager != null)
        {
            manager.ShowSubtitle("Teste de legenda funcionando!", 3f);
        }
        else
        {
            Debug.LogError("SubtitleManager não encontrado na cena!");
        }
    }
}