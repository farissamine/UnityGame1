using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 600f;
    //public float backwardsForce = 600f;
    public float sidewaysForce = 100f;
    public float jumpForce = 500f;
    private bool moveForwards = true;
    private bool moveBackwards = false;
    private bool moveRight = false;
    private bool moveLeft = false;
    private bool jumpAvailable = true;
    private bool jumping = false;

    ForceMode fm = ForceMode.VelocityChange;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start Occurred");
        //rb.AddForce(0,200, 500);
    }


    void Update()
    {

        if (Input.GetKeyDown("w"))
        {
            //moveForwards = true;
        }
        if (Input.GetKeyUp("w"))
        {
            //moveForwards = false;
        }


        if (Input.GetKeyDown("s"))
        {
            //moveBackwards = true;
        }
        if (Input.GetKeyUp("s"))
        {
           //moveBackwards = false;
        }



        if (Input.GetKeyDown("d"))
        {
            moveRight = true;
        }
        if (Input.GetKeyUp("d"))
        {
            moveRight = false;
        }


        if (Input.GetKeyDown("a"))
        {
            moveLeft = true;
        }
        if (Input.GetKeyUp("a"))
        {
            moveLeft = false;
        }


        if (Input.GetKeyDown("space"))
        {
            jumping = true;
           
            
        }
    }

    // Update is called once per frame
    void FixedUpdate()//FixedUpdate better for physics
    {
        if (moveForwards)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        if (moveBackwards)
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }

        if (moveRight)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, fm);
        }
        if (moveLeft)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, fm);
        }
        if (jumping)
        {
            if (jumpAvailable) { jump(); }
        }
        
    }


    public bool hasJump(){return jumpAvailable;}
    public void setJumpAvailable(bool j) { jumpAvailable = j; }

    private void jump() {
        rb.AddForce(0, jumpForce, 0);
        jumping = false;
        jumpAvailable = false;
    }
}
