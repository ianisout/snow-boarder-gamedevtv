using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 18f;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            surfaceEffector2D.speed = boostSpeed;
        }

        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            surfaceEffector2D.speed = baseSpeed;
        }

        // if (Input.GetKey(KeyCode.Space)) 
        // {
        //     surfaceEffector2D.speed = boostSpeed;
        // }

        // else 
        // {
        //     surfaceEffector2D.speed = baseSpeed;
        // }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.A)) 
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) 
        {
            rb2d.AddTorque(-torqueAmount);
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
