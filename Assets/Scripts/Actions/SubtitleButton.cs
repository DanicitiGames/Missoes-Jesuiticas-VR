using UnityEngine;
using TMPro;

public class SubtitleToggleButton : MonoBehaviour
{
    public SubtitleManager subtitleManager;
    public TextMeshProUGUI buttonText;

    private void Start()
    {
        UpdateButtonText();
    }

    public void ToggleSubtitles()
    {
        if (subtitleManager == null) return;

        subtitleManager.subtitlesEnabled = !subtitleManager.subtitlesEnabled;
        UpdateButtonText();

        Debug.Log("Legendas: " + (subtitleManager.subtitlesEnabled ? "ON" : "OFF"));
    }

    private void UpdateButtonText()
    {
        if (buttonText == null || subtitleManager == null) return;

        if (subtitleManager.subtitlesEnabled)
            buttonText.text = "Desligar Legenda";
        else
            buttonText.text = "Ligar Legenda";
    }
}
