using System.Threading;
using UnityEngine;

public class RoadSpawnerScript : MonoBehaviour
{
    public GameObject roadDividerPrefab; //Road Divider Prefab
    public static float interval = 0.6f; //Inerval is used for timer 
    private static float timer = 2; //Timer is used to keep track of last spawn time

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.IsGameOver())
        { //Check if the Game is Over or not.

            //Check if the timer has reached the 
            if (timer < interval)
            {
                timer += Time.deltaTime; //Increase the timer value.
            }
            else
            {
                SpawnRoadDivider(); //Otherwise, spawn a divider.
                timer = 0; //Reset the timer.
            }
        }
    }

    //This function helps to spawn road divider.
    private void SpawnRoadDivider()
    {
        //Instantiate the Pipe Prefab at random position along y-axis.
        Instantiate(roadDividerPrefab, transform.position, transform.rotation);
    }

    /* Function: Reset the timer.
     * We call this function when the game starts to
     * imemdiately start spawning the Pipes.
     */
    public static void ResetSpawnTimer()
    {
        timer = interval;
    }
}
