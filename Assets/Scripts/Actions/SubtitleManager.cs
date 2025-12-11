using System.Collections;
using UnityEngine;
using TMPro;

public class SubtitleManager : MonoBehaviour
{
    [Header("Referências")]
    public TextMeshProUGUI subtitleText;

    [Header("Configurações")]
    [Tooltip("Se > 0, limpa automaticamente após esse tempo. Se 0, usa duration passado em ShowSubtitleForClip.")]
    public float defaultAutoClearTime = 0f;

    [Header("Cores por personagem")]
    public Color apoenaColor = new Color(1f, 0.811f, 0.902f);
    public Color padreColor = new Color(0.6f, 1f, 0.6f); 
    public Color defaultColor = Color.white;

    private Coroutine clearRoutine;

    private void Awake()
    {
        if (subtitleText != null)
        {
            subtitleText.text = "";
            subtitleText.color = defaultColor;
        }
    }

    public void ShowSubtitle(string text)
    {
        if (clearRoutine != null) StopCoroutine(clearRoutine);

        if (subtitleText != null)
            subtitleText.text = text;
    }

    public void ShowSubtitle(string text, float duration)
    {
        if (clearRoutine != null) StopCoroutine(clearRoutine);

        if (subtitleText != null)
            subtitleText.text = text;

        if (duration > 0f)
            clearRoutine = StartCoroutine(AutoClear(duration));
    }

    public void ClearSubtitle()
    {
        if (clearRoutine != null) { StopCoroutine(clearRoutine); clearRoutine = null; }
        if (subtitleText != null)
        {
            subtitleText.text = "";
            subtitleText.color = defaultColor;
        }
    }

    // Mantive o método vazio original caso queira reutilizar
    public void subtitleColor(){
        
    }

    private IEnumerator AutoClear(float time)
    {
        clearRoutine = null;
        yield return new WaitForSeconds(time);
        ClearSubtitle();
    }

    public void ShowSubtitleForClip(AudioClip clip, float durationForClear = -1f)
    {
        if (clip == null)
        {
            Debug.LogWarning("SubtitleManager: clip é nulo.");
            ClearSubtitle();
            return;
        }

        TextAsset textFile = Resources.Load<TextAsset>("Subtitles/" + clip.name);
        if (textFile == null)
        {
            Debug.LogWarning($"SubtitleManager: nenhum arquivo encontrado em Resources/Subtitles/{clip.name}.txt para o clip chamado '{clip.name}'.");
            ClearSubtitle();
            return;
        }

        string subtitle = textFile.text ?? "";
        if (string.IsNullOrWhiteSpace(subtitle))
        {
            Debug.Log($"SubtitleManager: arquivo de legenda vazio para '{clip.name}'.");
            ClearSubtitle();
            return;
        }

        
        ApplySubtitleColorByFilename(clip.name);

        float durationToUse = 0f;
        if (durationForClear > 0f) durationToUse = durationForClear;
        else if (defaultAutoClearTime > 0f) durationToUse = defaultAutoClearTime;
        else durationToUse = 0f;

        if (durationToUse > 0f)
            ShowSubtitle(subtitle, durationToUse);
        else
            ShowSubtitle(subtitle); 

        Debug.Log($"SubtitleManager: mostrando legenda para '{clip.name}' (duração auto-clear: {durationToUse}s).");
    }

    private void ApplySubtitleColorByFilename(string filename)
    {
        if (subtitleText == null) return;
        if (string.IsNullOrEmpty(filename))
        {
            subtitleText.color = defaultColor;
            return;
        }

        string lower = filename.ToLowerInvariant();

        if (lower.StartsWith("apoena"))
        {
            subtitleText.color = apoenaColor;
        }
        else if (lower.StartsWith("padre"))
        {
            subtitleText.color = padreColor;
        }
        else
        {
            subtitleText.color = defaultColor;
        }
    }
}