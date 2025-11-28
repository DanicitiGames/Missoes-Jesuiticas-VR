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

    private Coroutine clearRoutine;

    private void Awake()
    {
        if (subtitleText != null)
            subtitleText.text = "";
    }

    // Mostra texto já carregado
    public void ShowSubtitle(string text)
    {
        if (clearRoutine != null) StopCoroutine(clearRoutine);

        if (subtitleText != null)
            subtitleText.text = text;
    }

    // Mostra texto por 'duration' segundos (usa coroutine)
    public void ShowSubtitle(string text, float duration)
    {
        if (clearRoutine != null) StopCoroutine(clearRoutine);

        if (subtitleText != null)
            subtitleText.text = text;

        if (duration > 0f)
            clearRoutine = StartCoroutine(AutoClear(duration));
    }

    // Limpa imediatamente
    public void ClearSubtitle()
    {
        if (clearRoutine != null) { StopCoroutine(clearRoutine); clearRoutine = null; }
        if (subtitleText != null) subtitleText.text = "";
    }

    private IEnumerator AutoClear(float time)
    {
        clearRoutine = null;
        yield return new WaitForSeconds(time);
        ClearSubtitle();
    }

    // --- NOVO: carrega arquivo texto a partir de Resources/Subtitles pelo nome do AudioClip ---
    /// <summary>
    /// Carrega e mostra o arquivo Assets/Resources/Subtitles/{clip.name}.txt
    /// Se durationForClear > 0, usa esse tempo; se <= 0 e defaultAutoClearTime > 0 usa o default; se ambos 0, não limpa automaticamente.
    /// </summary>
    public void ShowSubtitleForClip(AudioClip clip, float durationForClear = -1f)
    {
        if (clip == null)
        {
            Debug.LogWarning("SubtitleManager: clip é nulo.");
            ClearSubtitle();
            return;
        }

        // tenta carregar TextAsset em Resources/Subtitles/<clip.name>
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

        // decide duração para limpar
        float durationToUse = 0f;
        if (durationForClear > 0f) durationToUse = durationForClear;
        else if (defaultAutoClearTime > 0f) durationToUse = defaultAutoClearTime;
        else durationToUse = 0f;

        if (durationToUse > 0f)
            ShowSubtitle(subtitle, durationToUse);
        else
            ShowSubtitle(subtitle); // fica até ClearSubtitle ser chamado manualmente

        Debug.Log($"SubtitleManager: mostrando legenda para '{clip.name}' (duração auto-clear: {durationToUse}s).");
    }
}
