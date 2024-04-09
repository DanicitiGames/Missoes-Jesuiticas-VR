using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHead : MonoBehaviour
{
    public GameObject head;
    private void Update()
    {
        Vector3 position = transform.position;
        position.y = head.transform.position.y;
        transform.position = position;
    }
}
