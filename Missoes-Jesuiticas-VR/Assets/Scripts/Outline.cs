using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    public bool isOutline = false;
    public Material[] materials;
    public Color outlineOn;
    public Color outlineOff;
    private bool _isOutline = false;

    private void Start()
    {
        foreach (var material in materials)
        {
            material.SetFloat("_OutlineWidth", 0.08f);
            material.SetColor("_OutlineColor", outlineOff);
        }
    }
    private void Update()
    {
        if (isOutline == _isOutline) return;
        else _isOutline = isOutline;
        foreach (var material in materials)
        {
            material.SetFloat("_OutlineWidth", isOutline ? 0.16f : 0.08f);
            material.SetColor("_OutlineColor", isOutline ? outlineOn : outlineOff);
        }
    }

    public void ToggleOutline(bool value)
    {
        isOutline = value;
    }
}
