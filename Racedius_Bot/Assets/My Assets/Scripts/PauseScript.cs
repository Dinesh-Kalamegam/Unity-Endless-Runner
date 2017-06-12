using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {
    public float time;

    // The string that is used to refer to the main menu 
    public string mainMenu;

    // Boolean to determine whether the game is paused 
    public static bool isPaused;

    // The GameObject will hold the PauseMenu canvas for it to be set active/unactive
    public GameObject pauseMenuCanvas;


    void Update()
    {
        // In update so the player can press pause button any time in game


        
        if (isPaused)
        {
            // bring up pause menu and makes the time scale 0 so player cannot move their character
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }

        else
        {
            // Get rid of the pause menu and play game normally 
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        // If player presses escape then the state of isPaused reverses. (not paused --> pause) and (pause --> unpause)  
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

    }

    public void MainMenu()
    {
        // On the mouseclick to the main menu option 

        // unpause the game --> so that time scale is back to normal 
        isPaused = false;

        // reset the playerscore to 0
        // IT has to be set to 0 since it was a static variable. The value would carry over to the next game 
        //ScoreScript.score = 0;

        // Load the main menu 
        SceneManager.LoadScene(mainMenu);
        
    }

}
