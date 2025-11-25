using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    
    [SerializeField] InputActionReference gripInputAction;
    [SerializeField] InputActionReference triggerInputAction;
    
    private Animator handAnimator;

    private const string trigger = "Trigger";
    private const string grip = "Grip";

    private void Awake() 
    {
        handAnimator = GetComponent<Animator>();
    }

    private void OnEnable() 
    {
        gripInputAction.action.performed += gripPressed;
        triggerInputAction.action.performed += triggerPressed;

    }

    private void OnDisable() 
    {
        gripInputAction.action.performed -= gripPressed;
        triggerInputAction.action.performed -= triggerPressed;
    }

    private void gripPressed(InputAction.CallbackContext obj) 
    {
        handAnimator.SetFloat(grip, obj.ReadValue<float>());
    }

    private void triggerPressed(InputAction.CallbackContext obj) 
    {
        handAnimator.SetFloat(trigger, obj.ReadValue<float>());
    }
}
