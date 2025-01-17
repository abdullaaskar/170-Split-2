﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatMoveUD : MonoBehaviour
{
    //rigid body is rigid body
    public Rigidbody2D rb;

    //enemy movement variable
    public int enemySpeed = 3;
    public int verticalDirection;

    //condition and timer



    // Update is called once per frame
    void Update()
    {
        //comment out for raycast code, maybe needed for future movement
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(horizontalDirection, 0));*/

        rb.velocity = new Vector2(verticalDirection * enemySpeed, rb.velocity.x);
        //rb.constraints = RigidbodyConstraints2D.FreezePositionX;

        //Debug.Log(rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // if collide with Air Wall
        if (col.tag == "Air_Wall")
        {
            Flip();
        }
        
        if(col.tag == "Player")
        {
            col.GetComponent<Rigidbody2D>().transform.SetParent(transform);
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<Rigidbody2D>().transform.SetParent(null);
        }

    }


    //turn the horizontal direction to the other way
    void Flip()
    {
        if (verticalDirection > 0)
        {
            verticalDirection = -1;
        }
        else
        {
            verticalDirection = 1;
        }


    }


}
