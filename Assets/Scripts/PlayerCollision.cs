using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement movement;
    GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        if (gm)
        {
            Debug.Log("GameManager object found " + gm.name);
        }
        else
        {
            Debug.Log("No GameManager Object found");
        }
    }

    void OnCollisionEnter( Collision collisionInfo)
    {
        Debug.Log( collisionInfo.collider.name);

        if(collisionInfo.collider.tag == "Ground")
        {
            Debug.Log("We hit the Ground");
            if (!movement.hasJump())
            {
                movement.setJumpAvailable(true);
            }
        }

        if(collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("We hit an obstacle");

            movement.enabled = false;
            gm.EndGame();
            
        }
    }   
}
