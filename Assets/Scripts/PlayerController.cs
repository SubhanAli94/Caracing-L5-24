using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRigidBody; //RigidBody of the Player
    public float jumpForce = 5f; // Player's jump speed
    public bool isJumpTriggered = false; //To check whether the player should jump or not

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.IsGameOver())
        {
            //If the Space button is pressed on Keybaord then call the Shoot function.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Allow the player to jump up in the FixedUpdate function
                isJumpTriggered = true;
            }

            //Game is over if the player goes out of view from the bottom edge. 
            if (transform.position.y < -6)  
            {
                isJumpTriggered = false; //Disallow further jumps, immediately.

                GameManager.instance.GameOver(); //Game Over

                KillAllPipes(); //Kill all pipe game objects
            }
        }
    }

    void FixedUpdate()
    {
        if (isJumpTriggered) //Check if the jump is allowed
        {
            //Jump up with the force defined in jumpForce variable.
            playerRigidBody.velocity = Vector2.up * jumpForce; 

            //Disallow further jumps until next Space key stroke.
            isJumpTriggered= false;
        }
    }

    //This function checks whether the player collides with any obstacle.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the player collided with top or bottom pipe.
        if (collision.gameObject.CompareTag("Pipe"))
        {
            GameManager.instance.GameOver(); //Game Over.

            KillAllPipes(); //Clear the screen by deleting all the spawned pipes.
        }

        //Check if the Player passed through permissible area between pipes.
        if (collision.gameObject.CompareTag("AreaToPass") && !GameManager.instance.IsGameOver())
        {

            Debug.Log("Area to Pass is called.");
            GameManager.instance.AddScore(); //Add Score
        }

    }

    //This function kill all pipes which are spawned and yet to be killed.
    private void KillAllPipes()
    {
        // Find all pipe game objects
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("PipesParent");


        // Loop through each pipe object
        foreach (GameObject obj in objectsWithTag)
        {
            // Destroy the object if it's visible
            Destroy(obj);
        }
    }
}
