using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource completoAudio;
    public AudioSource baixoAudio;
    public AudioSource contraltoAudio;
    public AudioSource sopranoAudio;
    public AudioSource tenorAudio;

    public void ToggleCompleto(bool value)
    {
        if (value) completoAudio.Play();
        else completoAudio.Stop();
    }

    public void ToggleBaixo(bool value)
    {
        if (value) baixoAudio.Play();
        else baixoAudio.Stop();
    }

    public void ToggleContralto(bool value)
    {
        if (value) contraltoAudio.Play();
        else contraltoAudio.Stop();
    }

    public void ToggleSoprano(bool value)
    {
        if (value) sopranoAudio.Play();
        else sopranoAudio.Stop();
    }

    public void ToggleTenor(bool value)
    {
        if (value) tenorAudio.Play();
        else tenorAudio.Stop();
    }
}
