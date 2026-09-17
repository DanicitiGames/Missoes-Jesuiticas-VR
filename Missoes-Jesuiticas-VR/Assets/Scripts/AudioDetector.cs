using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class AudioDetector : MonoBehaviour
{
    public VRMBlendShapeProxy blendShapeProxy;
    public float loudness = 0.5f;
    public float sensitivity = 100;
    public float colorLerpSpeed = 10;
    public bool isAwaiting = false;

    private AudioSource audioSource;

    private void Start()
    {
        blendShapeProxy = GetComponent<VRMBlendShapeProxy>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float[] spectrum = new float[256];
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        float sum = 0;
        for (int i = 0; i < spectrum.Length; i++)
        {
            sum += spectrum[i];
        }

        float average = sum / spectrum.Length;
        loudness = average * sensitivity;

        if (loudness > 1)
        {
            loudness = 1;
        }

        blendShapeProxy.SetValue(BlendShapePreset.Fun, 0.3f);
        blendShapeProxy.SetValue(BlendShapePreset.A, loudness);
    }
}
