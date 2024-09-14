using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GiveToyToPlayer : MonoBehaviour
{
    [SerializeField] private GameObject ToyTransform;
    [SerializeField] private Transform HandTransform;
    [SerializeField] private Animator animator;
    [SerializeField] private float timeWaitingToPickItem = 20f;
    private GameObject instantiatedToy;
    private LTDescr destroyItemTween;

    const float timeToGiveItemAnimation = 1f;

    public void GiveToy()
    {
        animator.SetBool("isHoldingItem", true);
        instantiatedToy = Instantiate(ToyTransform, HandTransform);
        instantiatedToy.GetComponent<XRGrabInteractable>().selectEntered.AddListener(PlayerGrabbedItem);
        instantiatedToy.GetComponent<XRGrabInteractable>().selectExited.AddListener(RemoveItemParent);

        destroyItemTween = LeanTween.delayedCall(timeWaitingToPickItem, () => {
            animator.SetBool("isHoldingItem", false);
            instantiatedToy.GetComponent<XRGrabInteractable>().selectEntered.RemoveListener(PlayerGrabbedItem);
            Destroy(instantiatedToy, timeToGiveItemAnimation);
            this.enabled = false;
        });

    }

    public void PlayerGrabbedItem(SelectEnterEventArgs args)
    {
        LeanTween.cancel(destroyItemTween.id);
        animator.SetTrigger("GrabbedItem");
        animator.SetBool("isHoldingItem", false);
        this.enabled = false;
    }

    public void RemoveItemParent(SelectExitEventArgs args)
    {
        instantiatedToy.transform.parent = transform;
    }
 }
