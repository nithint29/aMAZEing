using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    public Vector3 initialPosition;

    // Use this for initialization
    void Start()
    {
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        if (currentPosition.y < -100) {
            Respawn();
        }
    }

    public void Respawn() {
        // TODO animation

        transform.position = initialPosition;

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

}
