using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadNodVerifier : MonoBehaviour
{
    public bool isNodding = false;
    public Transform head;

    private bool up = false;
    private bool down = false;
    private bool isGoingUp = false;
    private float lastX = 0;
    private float cooldown = 2f;

    private void Update()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime;
        else up = down = false;

        isGoingUp = head.rotation.x > lastX;

        if (head.rotation.x*180 < -30 && isGoingUp && !up)
        {
            up = true;
            cooldown = 2f;
        }
        if (head.rotation.x*180 > 30 && !isGoingUp && !down)
        {
            down = true;
            cooldown = 2f;
        }

        Debug.Log("up: " + up + " down: " + down + " rotation: " + head.rotation.x*180);

        if(up && down) isNodding = true;
        else isNodding = false;

        lastX = head.rotation.x;
    }
}
