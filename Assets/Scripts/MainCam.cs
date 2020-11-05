using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    private Transform ourDrone;
    // Start is called before the first frame update
    void Start()
    {
        ourDrone = GameObject.FindGameObjectWithTag("drone").transform;
    }

    private Vector3 velocityCameraFollow;
    public Vector3 behindPosition = new Vector3(0, 2, -4);
    public float angle;
    
    void CreateText(string text)
    {
        var path = @"LOG";

        //string text = "old falcon";
        File.WriteAllText(path, text);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, ourDrone.transform.TransformPoint(behindPosition) //+ Vector3.up * Input.GetAxis("Vertical")
                                                , ref velocityCameraFollow, 0.07f);
        transform.rotation = Quaternion.Euler(new Vector3(angle, ourDrone.GetComponent<DroneControl>().currentYRotation, 0));

        // Write coordinates in file
        string pos_x = "", pos_y = "", pos_z = "";
        pos_x = Convert.ToString(transform.position.x);
        pos_y = Convert.ToString(transform.position.y);
        pos_z = Convert.ToString(transform.position.z);
        string rot_x = "", rot_y = "", rot_z = "";
        rot_x = Convert.ToString(transform.eulerAngles.x);
        rot_y = Convert.ToString(transform.eulerAngles.y);
        rot_z = Convert.ToString(transform.eulerAngles.z);
        string text = pos_x + " " + pos_y + " " + pos_z + "\n" + rot_x + " " + rot_y + " " + rot_z;
        CreateText(text);
    }
}
