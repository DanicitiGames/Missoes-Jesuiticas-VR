using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    private Animator _animator;

    void Start() 
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        _animator.SetFloat("Trigger", triggerValue);

        float gripValue = gripAnimationAction.action.ReadValue<float>();
        _animator.SetFloat("Grip", gripValue);
    }
}
