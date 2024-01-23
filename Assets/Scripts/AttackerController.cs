using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerController : MonoBehaviour
{

    public GameObject ball;
    public GameObject playerCamera;

    public bool holdingBall = true;

    public float ballDistance;
    public float ballThrowingForce;


    void Start()
    {
        ball.GetComponent<Rigidbody> ().useGravity = false;

    }

    void Update()
    {
        if(holdingBall)
        {
        ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;

            if (Input.GetMouseButtonDown(0))
            {
                holdingBall = false;
                ball.GetComponent<Rigidbody>().useGravity = true;
                ball.GetComponent<Rigidbody>().AddForce (playerCamera.transform.forward * ballThrowingForce);
            }
        }
    }
}
