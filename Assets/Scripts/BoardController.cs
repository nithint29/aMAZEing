using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoardController : MonoBehaviour {

    public GameObject HandObj;
    public float moveSpeed = 10f;
    public float angleThreshold = 80.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void altUpdate () {

        hand _hand = HandObj.GetComponent<hand>();
        Debug.Log(_hand.yaw);

        /*
        KeyCode kcNegative = KeyCode.A;
        KeyCode kcPositive = KeyCode.D;
        Vector3 v3Rotation = new Vector3(1.0f, 0.0f, 0.0f);

        if (Input.GetKey(kcPositive))
            transform.Rotate(v3Rotation);
        if (Input.GetKey(kcNegative))
            transform.Rotate(-v3Rotation);
            */


        // float roll = Input.GetAxis("Horizontal");
        // float pitch = Input.GetAxis("Vertical");
        float deltaRoll = _hand.getDeltaRoll();
        //(Input.GetKey(KeyCode.D) ? 1f : 0f) -
        //(Input.GetKey(KeyCode.A) ? 1f : 0f);

        float deltaPitch = _hand.getDeltaPitch();
        //(Input.GetKey(KeyCode.W) ? 1f : 0f) -
        //(Input.GetKey(KeyCode.S) ? 1f : 0f);

        float deltaYaw = _hand.getDeltaYaw();
                    //(Input.GetKey(KeyCode.RightArrow) ? 1f : 0f) -
            //(Input.GetKey(KeyCode.LeftArrow) ? 1f : 0f);

        Vector3 currentRotation = transform.localRotation.eulerAngles;

        // Pitch: rotate around x-axis
        // TODO this sucks if (deltaPitch > 0 && currentRotation.x > 270
        transform.Rotate(Vector3.right, - deltaPitch * moveSpeed * Time.deltaTime);

        // Roll: rotate around z-axis
        transform.Rotate(Vector3.forward, deltaRoll * moveSpeed * Time.deltaTime);

        // Yaw: rotate around y-axis
        transform.Rotate(Vector3.up, deltaYaw * moveSpeed * Time.deltaTime);

        // Debug.Log(currentRotation);

        /*
        float minRotation = 270;
        float maxRotation = 90;

        currentRotation.x = Utils.ClampAngle(currentRotation.x, minRotation, maxRotation);
        currentRotation.z = Utils.ClampAngle(currentRotation.z, minRotation, maxRotation);
        transform.localRotation = Quaternion.Euler(currentRotation);
        */

        /*
        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        GetComponent<Rigidbody>().velocity += movement * moveSpeed * Time.deltaTime;
        */
	}

    void Update()
    {

        hand _hand = HandObj.GetComponent<hand>();
        // Debug.Log(_hand.yaw);

        /*
        KeyCode kcNegative = KeyCode.A;
        KeyCode kcPositive = KeyCode.D;
        Vector3 v3Rotation = new Vector3(1.0f, 0.0f, 0.0f);

        if (Input.GetKey(kcPositive))
            transform.Rotate(v3Rotation);
        if (Input.GetKey(kcNegative))
            transform.Rotate(-v3Rotation);
            */


        // float roll = Input.GetAxis("Horizontal");
        // float pitch = Input.GetAxis("Vertical");
        float deltaRoll = _hand.getDeltaRoll();
        //(Input.GetKey(KeyCode.D) ? 1f : 0f) -
        //(Input.GetKey(KeyCode.A) ? 1f : 0f);

        float deltaPitch = _hand.getDeltaPitch();
        //(Input.GetKey(KeyCode.W) ? 1f : 0f) -
        //(Input.GetKey(KeyCode.S) ? 1f : 0f);

        float deltaYaw = _hand.getDeltaYaw();
        //(Input.GetKey(KeyCode.RightArrow) ? 1f : 0f) -
        //(Input.GetKey(KeyCode.LeftArrow) ? 1f : 0f);

        Vector3 currentRotation = transform.localRotation.eulerAngles;

        // Pitch: rotate around x-axis
        // TODO this sucks if (deltaPitch > 0 && currentRotation.x > 270
        //      transform.Rotate(Vector3.right, -1/(Mathf.Abs(_hand.pitch - _hand.nuetPitch)) * moveSpeed * Time.deltaTime);

        //      // Roll: rotate around z-axis
        //transform.Rotate(Vector3.forward, -1/(Mathf.Abs(_hand.roll - _hand.nuetRoll)) * moveSpeed * Time.deltaTime);

        //// Yaw: rotate around y-axis
        //transform.Rotate(Vector3.up, deltaYaw * moveSpeed * Time.deltaTime);

        //transform.eulerAngles.Set(_hand.getDeltaPitch(),_hand.getDeltaYaw(), _hand.getDeltaRoll());
        //float xRot = (Mathf.Abs(_hand.getDeltaPitch() * 180.0f / Mathf.PI) > angleThreshold) ? (ang );
        //float yRot = _hand.getDeltaYaw() * 180.0f / Mathf.PI;
        //float zRot = _hand.getDeltaRoll() * 180.0f / Mathf.PI


        transform.localRotation = Quaternion.Euler(_hand.getDeltaPitch(), _hand.getDeltaYaw(), _hand.getDeltaRoll());

	}
}
    