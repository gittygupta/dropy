using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class DroneControl : MonoBehaviour
{
    Rigidbody ourDrone;
    // Start is called before the first frame update
    void Start()
    {
        ourDrone = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementUpDown();
        MovementForward();
        Rotation();
        ClampingSpeedValues();
        Swerve();

        ourDrone.AddRelativeForce(Vector3.up * upForce);
        ourDrone.rotation = Quaternion.Euler(
                new Vector3(tiltAmountForward, currentYRotation, tiltAmountSideways)
                );
        /*
        // Write coordinates in file
        string pos_x = "", pos_y = "", pos_z = "";
        pos_x = Convert.ToString(ourDrone.transform.position.x);
        pos_y = Convert.ToString(ourDrone.transform.position.y);
        pos_z = Convert.ToString(ourDrone.transform.position.z);
        string rot_x = "", rot_y = "", rot_z = "";
        rot_x = Convert.ToString(ourDrone.transform.eulerAngles.x);
        rot_y = Convert.ToString(ourDrone.transform.eulerAngles.y);
        rot_z = Convert.ToString(ourDrone.transform.eulerAngles.z);
        string text = pos_x + " " + pos_y + " " + pos_z + "\n" + rot_x + " " + rot_y + " " + rot_z;
        CreateText(text);*/
    }
    /*
    void CreateText(string text)
    {
        var path = @"LOG.txt";

        //string text = "old falcon";
        File.WriteAllText(path, text);
    }
    */

    public float upForce;
    
    void MovementUpDown()
    {
        // Correcting upForce (When pressing forward, drone comes down. To correct that)
        // Also when drone comes back
        if ((Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f) || (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f))
        {
            if (Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K))
            {
                ourDrone.velocity = ourDrone.velocity;
            }
            if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L))
            {
                ourDrone.velocity = ourDrone.velocity;
                upForce = 9.81f; // 9;
            }
            if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L)))
            {
                ourDrone.velocity = ourDrone.velocity;
                upForce = 9.81f; // 3.5f;
            }
            if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L))
            {
                upForce = 9.81f; // 13;
            }
        }
        if ((Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f) || (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f))
        {
            upForce = 9.92f; // 4.5f;
        }


        // UpDown Movement
        if (Input.GetKey(KeyCode.I))
        {
            upForce = 20;
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
            {
                upForce = 40; // 16.6f;
            }
        }
        else if (Input.GetKey(KeyCode.K))
        {
            upForce = -20;
        }
        else if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f))
        {
            upForce = 9.81f;
        }
    }

    private float movementForwardSpeed = 0.15f;    // speed
    private float tiltAmountForward = 0;
    private float tiltVelocityForward;

    void MovementForward()
    {
        /*
        if (Input.GetAxis("Vertical") != 0)
        {
            ourDrone.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * movementForwardSpeed);
            tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 5 * Input.GetAxis("Vertical"), ref tiltVelocityForward, 0.1f);
        }
        */
        if (Input.GetKey(KeyCode.W))
        {
            ourDrone.transform.localPosition += ourDrone.transform.forward * movementForwardSpeed;
            //tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 5 * Input.GetAxis("Vertical"), ref tiltVelocityForward, 0.1f);
            //ourDrone.transform.localPosition += new Vector3(sideMovementAmount, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            ourDrone.transform.localPosition -= ourDrone.transform.forward * movementForwardSpeed;
            //tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 5 * Input.GetAxis("Vertical"), ref tiltVelocityForward, 0.1f);
            //ourDrone.transform.localPosition -= new Vector3(sideMovementAmount, 0, 0);
        }
    }

    private float wantedYRotation;
    [HideInInspector]public float currentYRotation;
    private float rotateAmountByKeys = 1.0f;
    private float rotationYVelocity;

    void Rotation()
    {
        if (Input.GetKey(KeyCode.J))
        {
            wantedYRotation -= rotateAmountByKeys;
        }
        if (Input.GetKey(KeyCode.L))
        {
            wantedYRotation += rotateAmountByKeys;
        }

        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
    }

    private Vector3 velocityToSmoothDampToZero;
    void ClampingSpeedValues()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 5.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            ourDrone.velocity = Vector3.SmoothDamp(ourDrone.velocity, Vector3.zero, ref velocityToSmoothDampToZero, 0.95f);
        }
    }

    private float sideMovementAmount = 0.15f;
    private float tiltAmountSideways;
    private float tiltAmountVelocity;
    void Swerve()
    {   /*
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            ourDrone.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * sideMovementAmount);
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, -5 * Input.GetAxis("Horizontal"), ref tiltAmountVelocity, 0.1f);
        }
        else
        {
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, 0, ref tiltAmountVelocity, 0.1f);
        }
        */
        if (Input.GetKey(KeyCode.D))
        {
            ourDrone.transform.localPosition += ourDrone.transform.right * sideMovementAmount;
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, -5 * Input.GetAxis("Horizontal"), ref tiltAmountVelocity, 0.1f);
            //ourDrone.transform.localPosition += new Vector3(sideMovementAmount, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            ourDrone.transform.localPosition -= ourDrone.transform.right * sideMovementAmount;
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, -5 * Input.GetAxis("Horizontal"), ref tiltAmountVelocity, 0.1f);
            //ourDrone.transform.localPosition -= new Vector3(sideMovementAmount, 0, 0);
        }
        else
        {
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, 0, ref tiltAmountVelocity, 0.1f);
        }

    }
}
