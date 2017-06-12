using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideSceneChange : MonoBehaviour {

    // variable holding a string which can be fed into loadscene 
    // avoid directly typing the name of the scene into DIRECT CODE 
    public string newScene;


    // If something colliders with the option 
    void OnTriggerEnter2D(Collider2D collider)
    {
        // if the colliding object was the player 
        if (collider.tag == "Player")

            // load the scene that is the value of newScene string
            SceneManager.LoadScene(newScene);
    }

}
