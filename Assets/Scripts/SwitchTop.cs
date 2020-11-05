using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTop : MonoBehaviour
{
    //public Transform Player;
    public Camera TopViewCam, ThirdPersonCam;
    public bool camSwitch = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camSwitch = !camSwitch;
            TopViewCam.gameObject.SetActive(camSwitch);
            ThirdPersonCam.gameObject.SetActive(!camSwitch);
        }
    }
}
