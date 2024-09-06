using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CoralCharacterSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent[] CallOnSelected;
    public UnityEvent[] CallOnUnselected;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        print("Selected character " + transform.name);
        foreach (var function in CallOnSelected)
        {
            function?.Invoke();
        }
    }

    /// <inheritdoc />
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        print("Unselected character " + transform.name);
        foreach (var function in CallOnUnselected)
        {
            function?.Invoke();
        }
    }
}
