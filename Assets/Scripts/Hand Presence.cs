using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    private InputDevice _rightController;
    private InputDevice _leftController;
    
    void Start()
    {
        var characteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        StartCoroutine(RepeatGetDevice(characteristics));
        
        characteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        StartCoroutine(RepeatGetDevice(characteristics));
    }

    private IEnumerator RepeatGetDevice(InputDeviceCharacteristics characteristics )
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
        while (devices.Count == 0)
        {
            yield return null;
            InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
        }
        if (devices[0].characteristics.HasFlag(InputDeviceCharacteristics.Right))
            _rightController = devices[0];
        else
            _leftController = devices[0];
    }

    void Update()
    {
        // if(_rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        //     Debug.Log("Pressing Primary Button on Right Controller");
        // if(_leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue2) && primaryButtonValue2)
        //     Debug.Log("Pressing Primary Button on Left Controller");
        // if(_rightController.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        //     Debug.Log("Trigger Pressed on Right Controller" + triggerValue);
        // if(_leftController.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue2) && triggerValue2 > 0.1f)
        //     Debug.Log("Trigger Pressed on Left Controller" + triggerValue2);
        // if(_rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
        //     Debug.Log("Primary Touchpad Touched on Right Controller" + primary2DAxisValue);
        // if(_leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue2) && primary2DAxisValue2 != Vector2.zero)
        //     Debug.Log("Primary Touchpad Touched on Left Controller" + primary2DAxisValue2);
    }
}
