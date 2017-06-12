using UnityEngine;
using UnityEngine.SceneManagement;


public class DestroyerScript : MonoBehaviour
{
    // The game over menu is placed here 
    public GameObject GameOverCanvas;

    // The player health 
    public bool isGameOver;

    public Camera mcamera;


    // if the destroyer gameobject collides with something 

    void OnTriggerEnter2D(Collider2D other)
    {
        // if it collides with the player its gameover
        // this is always when the player falls off the level 

        if (other.tag == "Player")
        {
            isGameOver = true;
            if (isGameOver == true)
            {
                // brings up the game over screen and freezes time 
                mcamera.GetComponent<CameraFollow>().enabled = false;
                GameOverCanvas.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        // otherwise if the gameobject has a parent 
        if (other.gameObject.tag == "Chaser")
                Debug.Log("ignore the chaser ");

        else if (other.gameObject.transform.parent)
        {

            // get the parent of the gameobject and destroy it 
            Destroy(other.gameObject.transform.parent.gameObject);

        }

        // if there is not parent 
        else
        {
            // just destroy the object 
            Destroy(other.gameObject);

        }
    }
}

