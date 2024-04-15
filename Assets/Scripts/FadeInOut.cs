using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public bool start = true;
    public bool fadeIn = true;
    
    private RawImage image;
    private float timer = 0;
    private bool fading = false;

    private void Start()
    {
        image = GetComponent<RawImage>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, start ? 1 : 0);
        fading = start;
        if(fading) timer = fadeIn ? 1 : 0;
    }

    private void Update()
    {
        if(!fading) return;
        
        if(fadeIn)
        {
            timer -= Time.deltaTime;
            if(timer <= 0) fading = false;
        }
        else
        {
            timer += Time.deltaTime;
            if(timer >= 1) fading = false;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, timer);
    }

    public void FadeIn()
    {
        fadeIn = true;
        fading = true;
        timer = 1;
    }

    public void FadeOut()
    {
        fadeIn = false;
        fading = true;
        timer = 0;
    }
}
