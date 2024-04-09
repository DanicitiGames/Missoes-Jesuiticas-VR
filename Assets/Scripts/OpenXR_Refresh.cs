using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class OpenXR_Refresh : MonoBehaviour
{
    private float timeoutcheck = 2f;
    void Update(){
    if (timeoutcheck <= 0) {
                if (!XRSettings.isDeviceActive) {
                    StartCoroutine(RestartXRCoroutine());
                }
                timeoutcheck = 2f;
            }
            timeoutcheck -= Time.deltaTime;
    }
     
    public IEnumerator RestartXRCoroutine() {
            StopXR();
            Debug.Log("Initializing XR...");
            yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
     
            if (XRGeneralSettings.Instance.Manager.activeLoader == null) {
                Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
            } else {
                XRGeneralSettings.Instance.Manager.StartSubsystems();
                Debug.Log($"Starting XR...{XRGeneralSettings.Instance.Manager.activeLoader.name} - {XRGeneralSettings.Instance.Manager.isInitializationComplete}");
            }
        }
     
        void StopXR() {
            Debug.Log("Stopping XR...");
     
            XRGeneralSettings.Instance.Manager.StopSubsystems();
            XRGeneralSettings.Instance.Manager.DeinitializeLoader();
            Debug.Log("XR stopped completely.");
        }
    void OnApplicationQuit() {
        StopXR();
    }
}
