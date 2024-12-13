using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    private float trackSpeed = 5f; //Road divider's speed

    // Update is called once per frame
    private void Update()
    {
        // Move the road divider downwards at a constant speed
        transform.Translate(0, -trackSpeed * Time.deltaTime, 0);

        // Check if the divider has moved past the bottom of the screen
        if (transform.position.y <= -(Camera.main.orthographicSize + 1))
        {
            Destroy(gameObject);
        }
    }
}
