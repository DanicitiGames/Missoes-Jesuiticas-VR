using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class HeightCalculator : MonoBehaviour
{
    public TextMeshProUGUI heightText;
    public TextMeshProUGUI differenceText;
    public TextMeshProUGUI resultText;
    public float difference = 1f;
    public GameObject head;
    private void Update()
    {
        heightText.text = "Altura atual: " + head.transform.position.y.ToString("F2") + "m";
        differenceText.text = "Diferença: " + difference.ToString("F2") + "m";
        resultText.text = "Resultado: " + (head.transform.position.y - difference).ToString("F2") + "m";
    }
    public void UpdateDifference()
    {
        difference = head.transform.position.y;
    }
}
