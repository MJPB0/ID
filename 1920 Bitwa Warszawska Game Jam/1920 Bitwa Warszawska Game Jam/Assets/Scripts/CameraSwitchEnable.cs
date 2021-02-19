using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchEnable : MonoBehaviour
{
    [SerializeField] CameraSwitch camSwitch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!camSwitch.gameObject.activeInHierarchy)
            {
                camSwitch.gameObject.SetActive(true);
            }
        }
    }
}
