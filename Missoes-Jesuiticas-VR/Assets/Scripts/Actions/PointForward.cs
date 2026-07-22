using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointForward : MonoBehaviour
{

    [SerializeField] private Animator animator;

    public void Point()
    {
        animator.SetTrigger("PointingForward");
    }
}
