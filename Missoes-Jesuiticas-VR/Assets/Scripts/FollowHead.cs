using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHead : MonoBehaviour
{
    public GameObject head;
    public bool lockY = false;
    private void Update()
    {
        Vector3 position = transform.position;
        position.y = head.transform.position.y;
        if(!lockY) transform.position = position;
        transform.LookAt(head.transform);
        transform.Rotate(0, 180, 0);
    }
}
