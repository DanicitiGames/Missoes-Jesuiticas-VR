using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LookToObject : MonoBehaviour
{
    [SerializeField] private float delayToLook = 1f;
    [SerializeField] private float rotateSpeed = 1f;
    [SerializeField] private float angleDistanceThreshold = 5;
    [SerializeField] private Transform objectToRotate;
    [SerializeField] private Transform objectToRotateTowards;
    [SerializeField] private bool callOnStart = false;

    private bool isRotating = false;

    private void Start()
    {
        if (callOnStart) RotateToObject();
    }

    public void RotateToObject()
    {
        LeanTween.delayedCall(delayToLook, () =>
        {
            isRotating = true;
        });
    }

    private void Update()
    {
        if (!isRotating) return;
        
        var targetRotation = Quaternion.LookRotation(objectToRotateTowards.position - objectToRotate.position);
        var str = Mathf.Min(rotateSpeed * Time.deltaTime, 1);
        objectToRotate.rotation = Quaternion.Lerp(objectToRotate.rotation, targetRotation, str);

        if (Vector3.Angle(objectToRotate.transform.forward, objectToRotateTowards.position - objectToRotate.transform.position) < angleDistanceThreshold) isRotating = false;
    
    }
}
