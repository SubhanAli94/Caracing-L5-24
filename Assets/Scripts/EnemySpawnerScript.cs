using System.Threading;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemyCarPrefab; //Enemy Car Prefab
    public static float interval = 1f; //Inerval is used for timer 
    private static float timer = 2; //Timer is used to keep track of last spawn time

    public Transform leftEdgeOfRoad; // Location of the left edge
    public Transform rightEdgeOfRoad; // Location of the right edge


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
        //Select random x
        float randomX = Random.Range(0, 2) == 0 ? leftEdgeOfRoad.position.x + 2.5f : rightEdgeOfRoad.position.x - 1.5f;

        //Set new pos
        Vector2 newPos = new Vector2(randomX, transform.position.y);


        //Instantiate the Pipe Prefab at random position along y-axis.
        Instantiate(enemyCarPrefab, newPos, transform.rotation);
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
