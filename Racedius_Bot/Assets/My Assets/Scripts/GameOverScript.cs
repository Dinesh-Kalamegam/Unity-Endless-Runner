using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOverScript : MonoBehaviour
{
    // Using the GUI style so that the text can be customised in the inspector further
    public GUIStyle style;

    // The place holder that will display the final score 
    public Text GameOverScore;

    // A sort of ranking system: Try Again, Not  Bad, Decent, Good , Epic, Legend, HERO 
    public Text feedback;

    // The first number (or two) of the score. It makes comparisons easier without needing inequalities
    private int dispscore;

    // for the main menu return button - string that is fed to function 
    public string mainMenu2;

    // for restart function - string of the scene name that is fed to function 
    public string levelname;

    // A comparative score will check for highscore 
    public int comparativeScore;


    // Use this for initialization
    void Start()
    {
        // Set the score display 

        GameOverScore.text = ("Score: " + (ScoreScript.score + ScoreScript.gears));

        // find the value of comparison score i.e. the first 1 or 2 numbers 

        dispscore = (int) ScoreScript.score/100;

        //Simple selection construct that determines feedback 
        // || was used to determine OR values so that no values are missed - robustness

        if (dispscore == 0)
        {
            feedback.text = ("Try Again!");
        }

        else if (dispscore == 1)
        {
            feedback.text =("Not Bad");
        }

        else if (dispscore == 2 || dispscore ==3 || dispscore ==4)
        {
            feedback.text = ("Decent");
        }

        else if (dispscore == 5 || dispscore ==6)
        {
            feedback.text = ("Good");
        }

        else if (dispscore == 7 || dispscore ==8 || dispscore ==9)
        {
            feedback.text = ("EPIC");
        }

        else if (dispscore == 10 || dispscore ==11 || dispscore ==12 || dispscore == 13 || dispscore ==14 || dispscore ==15)
        {
            feedback.text = ("Legend");
        }

        else if (dispscore > 15)
        {
            feedback.text = ("HERO");
        }

        else
        {
            feedback.text = ("Try Again ");
        }

        comparativeScore = ScoreScript.score;

        if (comparativeScore > PlayerPrefs.GetInt("HScore",0))
        {
            PlayerPrefs.SetInt("HScore", comparativeScore);
        }
        
    }

    // Finds the final score and lets it equal to GameOverScore 
    public void Awake()
    {
        GameOverScore = GameObject.Find("FinalScore").GetComponent<Text>();
    }

    // Same as the NewNavigation script only here time is set to 1f
    // This is to avoid the characer freezing at the main menu 

    public void MainMenu2()
    {
       // ScoreScript.score = 0;

        Time.timeScale = 1f;
        ScoreScript.gears = 0;
        comparativeScore = 0;
        EnemyScript.isGameOver = false;
        SceneManager.LoadScene(mainMenu2);
    }

    public void Restart()
    {
        //ScoreScript.score = 0;

        Time.timeScale = 1f;
        ScoreScript.gears = 0;
        EnemyScript.isGameOver = false;
        comparativeScore = 0;
        SceneManager.LoadScene(levelname);

    }
}

