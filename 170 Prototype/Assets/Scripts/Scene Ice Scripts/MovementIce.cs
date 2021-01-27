﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementIce : MonoBehaviour
{
    public Rigidbody2D rb;      // Rigidbody variable
    public float speed;         // player movement speed 
    public bool touchIce;       // Helps to determine in playermovement

    void Update()
    {
        Debug.Log("touchIce status1 = " + touchIce);
        //Movement();
    }

    void Movement(){
        // Get One Direction^^
        float horizontalmove;
        horizontalmove = Input.GetAxis("Horizontal");
        touchIce = false;

        // PlayerMovement method
        if(horizontalmove != 0){
            Debug.Log("Not on ice");
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
        }
    }

    // Collision detector, returns true while player keep coliding the ice
    private void OnCollisionStay2D(Collision2D col){
        // if collide with ice do sliding
        if(col.gameObject.tag == "Ice"){
            Debug.Log("Collision detected = "+touchIce);
            rb.velocity = new Vector2(speed, -10);
            touchIce = true;
            Debug.Log("touchIce status2 = "+touchIce);
        // if not collide do normal movement
        }else{
            Movement();
        }
  }
}
