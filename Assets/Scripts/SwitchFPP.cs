using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFPP : MonoBehaviour
{
    //public Transform Player;
    public Camera FirstPersonCam, ThirdPersonCam;
    public bool camSwitch = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camSwitch = !camSwitch;
            FirstPersonCam.gameObject.SetActive(camSwitch);
            ThirdPersonCam.gameObject.SetActive(!camSwitch);
        }
    }
}
