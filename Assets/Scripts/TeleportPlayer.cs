using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private Transform positionToTeleport;
    [SerializeField] private Transform playerGameObject;
    [SerializeField] private float delayToTeleport = 1f;

    public void Teleport()
    {
        LeanTween.delayedCall(delayToTeleport, () =>
        {
            if (positionToTeleport != null && playerGameObject != null)
            {
                playerGameObject.SetPositionAndRotation(positionToTeleport.position, positionToTeleport.rotation);
            }
        });
    }
}
