using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;

public class WriteLog : MonoBehaviour
{
    [SerializeField]
    GameObject[] aircrafts;
    //Rigidbody[] rbs;
    Rigidbody current_drone;

    Camera sceneCamera;

    void Start()
    {
        current_drone = GetComponent<Rigidbody>();
        aircrafts = GameObject.FindGameObjectsWithTag("drone");
        // initialize array with same number of elements
        //rbs = new Rigidbody[aircrafts.Length];
        // loop through each GameObject and cache its rigidbody
        /*
        for (int i = 0; i < aircrafts.Length; i++)
        {
            // get GameObject at index `i`
            GameObject drone = aircrafts[i];
            // set rigidbody at index `i`
            rbs[i] = drone.GetComponent<Rigidbody>();
        }
        */
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        string whole_text = "";
        for (int i = 0; i < rbs.Length; i++)
        {
            string pos_x = "", pos_y = "", pos_z = "";
            
            pos_x = Convert.ToString(rbs[i].transform.position.x);
            pos_y = Convert.ToString(rbs[i].transform.position.y);
            pos_z = Convert.ToString(rbs[i].transform.position.z);
            string rot_x = "", rot_y = "", rot_z = "";
            rot_x = Convert.ToString(rbs[i].transform.eulerAngles.x);
            rot_y = Convert.ToString(rbs[i].transform.eulerAngles.y);
            rot_z = Convert.ToString(rbs[i].transform.eulerAngles.z);
            string text = pos_x + " " + pos_y + " " + pos_z + "\n" + rot_x + " " + rot_y + " " + rot_z + "\n";
            whole_text += text;
            CreateText(whole_text);
            
        }
        */
        string pos_x = "", pos_y = "", pos_z = "";
        pos_x = Convert.ToString(current_drone.transform.position.x);
        pos_y = Convert.ToString(current_drone.transform.position.y);
        pos_z = Convert.ToString(current_drone.transform.position.z);
        string rot_x = "", rot_y = "", rot_z = "";
        rot_x = Convert.ToString(current_drone.transform.eulerAngles.x);
        rot_y = Convert.ToString(current_drone.transform.eulerAngles.y);
        rot_z = Convert.ToString(current_drone.transform.eulerAngles.z);
        string text = pos_x + " " + pos_y + " " + pos_z + "\n" + rot_x + " " + rot_y + " " + rot_z;
        CreateText(text);
    }

    void CreateText(string text)
    {
        string filename = "LOG" + aircrafts.Length.ToString() + ".txt";
        var path = @filename;

        //string text = "old falcon";
        File.WriteAllText(path, text);
    }
}
