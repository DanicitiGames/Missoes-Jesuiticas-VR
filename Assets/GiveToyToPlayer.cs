using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveToyToPlayer : MonoBehaviour
{
    [SerializeField] private GameObject ToyTransform;
    [SerializeField] private Transform HandTransform;

    public void GiveToy()
    {
        Instantiate(ToyTransform, HandTransform);
    }
}
