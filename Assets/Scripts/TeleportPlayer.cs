using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private Transform positionToTeleport;
    [SerializeField] private Transform playerGameObject;

    public void Teleport()
    {
        if (positionToTeleport != null && playerGameObject != null) { 
            playerGameObject.position = positionToTeleport.position;
        }
    }
}
