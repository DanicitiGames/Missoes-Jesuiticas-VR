using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;

    private void Start()
    {
        XRGrabInteractableTwoAttach interactable = GetComponent<XRGrabInteractableTwoAttach>();
        interactable.activated.AddListener(Fire);
    }

    public void Fire(ActivateEventArgs args)
    {
        GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 10, ForceMode.Impulse);
        Destroy(newBullet, 3);
    }
}
