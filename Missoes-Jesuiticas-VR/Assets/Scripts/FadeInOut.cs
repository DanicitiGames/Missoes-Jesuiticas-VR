using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public bool start = true;
    public bool fadeIn = true;
    private bool fadeInAndOut = false;
    
    private Renderer renderer;
    private float timer = 0;
    private bool fading = false;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
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
            if(timer >= 2) fading = false;
            
            if (!fading && fadeInAndOut)
            {
                fadeInAndOut = false;
                FadeIn();
            }
        }

        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, timer * 2);
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

    public void FadeInAndOut()
    {
        fadeInAndOut = true;
        FadeOut();
    }
}
