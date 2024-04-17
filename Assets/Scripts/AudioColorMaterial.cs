using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioColorMaterial : MonoBehaviour
{
    public Color silentColor = Color.white;
    public Color loudColor = Color.red;
    public Color awaitingColor = Color.yellow;
    public float loudness = 0.5f;
    public float sensitivity = 100;
    public float colorLerpSpeed = 10;
    public bool isAwaiting = false;

    private Material material;
    private AudioSource audioSource;
    private float actualSize = 0.1f;
    private float silentSize = 0.1f;
    private float loudSize = 0.12f;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(isAwaiting)
        {
            material.color = Color.Lerp(material.color, awaitingColor, Time.deltaTime * colorLerpSpeed);
            actualSize = Mathf.Lerp(actualSize, silentSize, Time.deltaTime * colorLerpSpeed);
            return;
        }

        float[] spectrum = new float[256];
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        float sum = 0;
        for (int i = 0; i < spectrum.Length; i++)
        {
            sum += spectrum[i];
        }

        float average = sum / spectrum.Length;
        loudness = average * sensitivity;

        material.color = Color.Lerp(material.color, loudness < 0.005f ? silentColor : loudColor, Time.deltaTime * colorLerpSpeed);
        actualSize = Mathf.Lerp(actualSize, loudness < 0.005f ? silentSize : loudSize, Time.deltaTime * colorLerpSpeed);
        transform.localScale = new Vector3(actualSize, actualSize, actualSize);
    }
}
