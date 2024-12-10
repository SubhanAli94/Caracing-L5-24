using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    //Pipe's horizontal speed
    public float moveSpeed = 5;

    //The deadzone to kill Pipe GameObjects if they're out of Game view.
    private float deadZone = -13;

    // Update is called once per frame
    void Update()
    {
        //Move the pipe along the x-axis from right to left.
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;


        if (transform.position.x < deadZone) //Check if the pipe reached the deadzone
        {
            Destroy(gameObject); //Kill the Pipe GameObject
        }
    }
}
