using UnityEngine;

public class PickUpsScript : MonoBehaviour
{
    // creates a private variable to hold the tag of the GameObject
    // this is done so that GameObject.FindWithTag ("")  does not have to be used every time

    private string collectible;


    // Function that changes the player score 
    // Other applies to the coin --> IF collider of OTHER (The coin) TOUCHES the collider of PLAYER

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // checks the tag of the object that just collided with player

            collectible = gameObject.tag;

            // destroys the gameObject that the player collided with (pick up effect) 
            Destroy(gameObject);

            if (collectible == "Green")
            {
                ScoreScript.gears += 1;
;
            }

            else if (collectible == "Yellow")
            {
                ScoreScript.gears += 2;

            }

            else if (collectible == "Blue")
                ScoreScript.gears += 3;

            }
        }

    }

