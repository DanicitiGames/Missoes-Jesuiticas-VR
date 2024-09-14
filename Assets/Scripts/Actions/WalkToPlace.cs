using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WalkToPlace : MonoBehaviour
{
    [SerializeField] private Transform positionToGo;
    [SerializeField] private Transform objectToMove;
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float delayToStart = 1;
    [SerializeField] private UnityEvent onReachPlace;

    void Update()
    {
        delayToStart -= Time.deltaTime;
        
        if(!objectToMove || !positionToGo || delayToStart > 0) return;


        if (Vector3.Distance(positionToGo.position, objectToMove.transform.position) > 0.2f)
        {
            if (animator != null) animator.SetBool("isWalking", true);

            Vector3 newPosition = Vector3.MoveTowards(objectToMove.position, positionToGo.position, moveSpeed * Time.deltaTime);
            objectToMove.LookAt(newPosition);
            objectToMove.position = newPosition;
        }
        else
        {
            if (animator != null) animator.SetBool("isWalking", false);
            onReachPlace?.Invoke();
            this.enabled = false;
        }
    }
}
