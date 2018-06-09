using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class hand : MonoBehaviour
{

    public HandController theHand;
    Leap.Hand firstHand = null;
    // Use this for initialization


    void Start()
    {
        theHand = GameObject.FindGameObjectWithTag("handControl").GetComponent<HandController>();

        Leap.Frame frame = theHand.GetFrame(); // controller is a Controller object
        Leap.HandList hands = frame.Hands;
        firstHand = hands[0];
        Debug.Log("starting");
    }

    public float pitch = 0;
    public float yaw = 0;
    public float roll = 0;
    // Update is called once per frame
    public float nuetPitch = 0.4f;
    public float nuetYaw = 0.07f;
    public float nuetRoll = 2.8f;

    public float maxAngleThreshold = 15.0f;
    public float minAngleThreshold = 1.0f;

    RigidHand rigidHand;
    void Update()
    {
        // Debug.Log("before getting object");
        theHand = GameObject.FindGameObjectWithTag("handControl").GetComponent<HandController>();
        //  Debug.Log("before getting frame");
        Leap.Frame frame = theHand.GetFrame(); // controller is a Controller object

        //  Debug.Log("before getting hands list");
        Leap.HandList hands = frame.Hands;
        rigidHand = GameObject.FindObjectOfType(typeof(RigidHand)) as RigidHand;

        float new_pitch = 0;
        float new_yaw = 0;
        float new_roll = 0;

        if (rigidHand != null)
        {
            new_pitch = rigidHand.GetPalmRotation().eulerAngles.x;
            new_yaw = rigidHand.GetPalmRotation().eulerAngles.y;
            new_roll = rigidHand.GetPalmRotation().eulerAngles.z;
        }
        //Debug.Log(rigidHand.GetPalmRotation().eulerAngles.ToString());

        //Debug.Log("before");
        //if (firstHand != null)
        //{
        //    firstHand = hands[0];

            Debug.Log("old pitch: " + pitch);
            Debug.Log("old yaw " + yaw);
            Debug.Log("old roll " + roll);
            /*
            float new_pitch = firstHand.Direction.Pitch;
            float new_yaw = firstHand.Direction.Yaw;
            float new_roll = firstHand.Direction.Roll;*/

            float pitch_diff = Math.Abs(new_pitch - pitch);
            float roll_diff = Math.Abs(new_roll - roll);
            float yaw_diff = Math.Abs(new_yaw - yaw);

            /*if (pitch_diff > maxAngleThreshold || pitch_diff < minAngleThreshold)
                new_pitch = pitch;
            if (roll_diff > maxAngleThreshold || roll_diff < minAngleThreshold)
                new_roll = roll;
            if (yaw_diff > maxAngleThreshold || yaw_diff < minAngleThreshold)
                new_yaw = yaw;*/

            pitch = new_pitch;
            roll = new_roll;
            yaw = new_yaw;



        Debug.Log("next");
        //Leap.Vector test;
        //test.
        //test.Pitch = 1;
        //test.Yaw = 2;
        //test.Roll = 3;
        if (Input.GetKey(KeyCode.R))
        {
            nuetPitch = rigidHand.GetPalmRotation().eulerAngles.x;
            nuetYaw = rigidHand.GetPalmRotation().eulerAngles.y;
            nuetRoll = rigidHand.GetPalmRotation().eulerAngles.z;
        }

    }
    public float getDeltaPitch()
    {
        //return rigidHand.GetPalmRotation().eulerAngles.x - nuetPitch;
        return (pitch - nuetPitch);
    }
    public float getDeltaYaw()
    {
        //return rigidHand.GetPalmRotation().eulerAngles.y - nuetYaw;
        return (yaw - nuetYaw);
    }
    public float getDeltaRoll()
    {
        //return rigidHand.GetPalmRotation().eulerAngles.z - nuetRoll;
        return (roll - nuetRoll);
    }    
}
