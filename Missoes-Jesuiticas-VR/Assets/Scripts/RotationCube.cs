using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCube : MonoBehaviour
{
    public float speed = 20f;
    public Vector3 axis = new Vector3(0, 1, 0.5f);

    void Update()
    {
        transform.Rotate(axis, speed * Time.deltaTime);
    }
}
