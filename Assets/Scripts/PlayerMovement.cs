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
    private int numJumps = 2;
    private int jumpHolder = 2;

    ForceMode fm = ForceMode.VelocityChange;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start Occurred");
        //rb.AddForce(0,200, 500);
        gm = FindObjectOfType<GameManager>();
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
        if (rb.position.y < -3f)
        {
            gm.EndGame();
        }
    }


    public bool hasJump(){return jumpAvailable;}
    public void setJumpAvailable(bool j) {
        jumpAvailable = j;
        //jumpHolder = 2;
    }

    private void jump() {
        rb.AddForce(0, jumpForce, 0);
        jumpAvailable = false;
        jumping = false;
        /*
        jumpHolder -= 1;
        if(jumpHolder == 0)
        {
            jumpAvailable = false;
        }*/
        
    }
}
