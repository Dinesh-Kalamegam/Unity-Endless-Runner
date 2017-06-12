using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text ScoreText;
    public Text GearText;
    public Text HScoreText;

    public static int score;

    public static int gears;

    public int HighScore;
        
    private Vector3 startPosition;


        void Start()
        {
            HighScore = PlayerPrefs.GetInt("HScore", 0);
        }

        void Awake()
        {
            startPosition = transform.position;
        }

        void Update()
        {

            score = Mathf.RoundToInt(Mathf.Abs(transform.position.x - startPosition.x));
            ScoreText.text = "Score  " + score.ToString();
            GearText.text = "Gears " + gears.ToString();
            HScoreText.text = "HighScore  " + HighScore.ToString();
        }


        public void OnGameOver()
        {
            transform.position = startPosition;
        }

}


