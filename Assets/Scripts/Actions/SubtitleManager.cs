using System.Collections;
using UnityEngine;
using TMPro;

public class SubtitleManager : MonoBehaviour
{
    
    public TextMeshProUGUI subtitleText;

    
    public float defaultAutoClearTime = 0f;

    private Coroutine clearRoutine;

    private void Awake()
    {
        if (subtitleText != null)
            subtitleText.text = "";
    }

    
    public void ShowSubtitle(string text)
    {
        
        if (clearRoutine != null) StopCoroutine(clearRoutine);

        if (subtitleText != null)
            subtitleText.text = text;

        if (defaultAutoClearTime > 0f)
            clearRoutine = StartCoroutine(AutoClear(defaultAutoClearTime));
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
        if (subtitleText != null) subtitleText.text = "";
    }

    private IEnumerator AutoClear(float time)
    {
        clearRoutine = null;
        yield return new WaitForSeconds(time);
        ClearSubtitle();
    }
}
