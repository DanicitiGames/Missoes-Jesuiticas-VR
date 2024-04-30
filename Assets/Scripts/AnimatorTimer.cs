using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTimer : MonoBehaviour
{
    public string[] animationNames;
    public float[] animationTimes;
    private Animator animator;
    private float timer;
    private int index = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        timer = animationTimes[index];
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            index++;
            if (index >= animationNames.Length)
            {
                Destroy(this);
                return;
            }
            animator.Play(animationNames[index]);
            timer = animationTimes[index];
        }
    }
}
