using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    private float originalY;
    public float floatStrength = 1;
    public float floatSpeed = 1;

    private void Start()
    {
        this.originalY = this.transform.position.y;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, originalY + ((float)Mathf.Sin(Time.time * floatSpeed) * floatStrength), transform.position.z);
    }
}
