using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    [SerializeField] InputActionReference gripInputAction;
    [SerializeField] InputActionReference triggerInputAction;

    private Animator handAnimator;

    private const string TRIGGER = "Trigger";
    private const string GRIP = "Grip";

    private void Awake()
    {
        handAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        gripInputAction.action.Enable();
        triggerInputAction.action.Enable();

        gripInputAction.action.performed += GripPressed;
        gripInputAction.action.canceled += GripPressed;

        triggerInputAction.action.performed += TriggerPressed;
        triggerInputAction.action.canceled += TriggerPressed;
    }

    private void OnDisable()
    {
        gripInputAction.action.Disable();
        triggerInputAction.action.Disable();

        gripInputAction.action.performed -= GripPressed;
        gripInputAction.action.canceled -= GripPressed;

        triggerInputAction.action.performed -= TriggerPressed;
        triggerInputAction.action.canceled -= TriggerPressed;
    }

    private void GripPressed(InputAction.CallbackContext ctx)
    {
        handAnimator.SetFloat(GRIP, ctx.ReadValue<float>());
    }

    private void TriggerPressed(InputAction.CallbackContext ctx)
    {
        handAnimator.SetFloat(TRIGGER, ctx.ReadValue<float>());
    }
}
