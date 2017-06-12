using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour
{
    // The game over menu is placed here 
    public GameObject GameOverCanvas;

    // The player health 
    public int health;


    // if the destroyer gameobject collides with something 

    void OnTriggerEnter2D(Collider2D other)
    {
        // if it collides with the player its gameover
        // this is always when the player alls off the level 

        if (other.tag == "Player")
        {
            health = 0;
            if (health == 0)
            {
                // brings up the game over screen and freezes time 

                GameOverCanvas.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
