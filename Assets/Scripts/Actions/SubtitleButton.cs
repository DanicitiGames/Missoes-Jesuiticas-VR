using UnityEngine;
using TMPro;

public class SubtitleToggleButton : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI buttonText;

    private void Start()
    {
        bool enabled = PlayerPrefs.GetInt("SubtitlesEnabled", 1) == 1;
        UpdateButtonText(enabled);
    }

    public void ToggleSubtitles()
    {
        bool current = PlayerPrefs.GetInt("SubtitlesEnabled", 1) == 1;
        bool next = !current;

        PlayerPrefs.SetInt("SubtitlesEnabled", next ? 1 : 0);
        PlayerPrefs.Save();

        UpdateButtonText(next);

        Debug.Log("Legendas agora estão: " + (next ? "LIGADAS" : "DESLIGADAS"));
    }

    private void UpdateButtonText(bool enabled)
    {
        if (buttonText == null) return;

        buttonText.text = enabled
            ? "Desligar Legenda"
            : "Ligar Legenda";
    }
}
