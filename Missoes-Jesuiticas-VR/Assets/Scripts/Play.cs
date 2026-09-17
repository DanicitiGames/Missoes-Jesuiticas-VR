using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public FadeInOut fadeInOut;
    private float timer = 2.5f;
    private bool started = false;

    public void StartGame()
    {
        fadeInOut.FadeOut();
        started = true;
    }

    private void Update()
    {
        if(!started) return;

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            started = false;
            SceneManager.LoadScene("Main");
        }
    }
}
