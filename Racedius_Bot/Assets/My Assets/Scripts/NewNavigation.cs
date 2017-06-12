using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class NewNavigation : MonoBehaviour

{ 
    public void ChangeScene(string ChangeToScene)
    { 
        SceneManager.LoadScene(ChangeToScene);
    }

    void Update()
    {
        // If the user presses escape 
        if (Input.GetKey("escape"))

            //Quit the game 
            Application.Quit();

    }

}

