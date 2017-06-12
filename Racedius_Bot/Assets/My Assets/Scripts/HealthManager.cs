using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    #region core health system variable declarations
    public float playerHealth;
    public float maxHealth;
    public Slider HealthBar;

    public float dmgmodifier; 

    public int spkDmg;
    public int acdDmg;
    public int penDmg;
    public int sawDmg;
    public int barDmg;
    public int droidDmg;

    public int acdCounter;

    public GameObject acdSkull1;
    public GameObject acdSkull2;
    public GameObject acdSkull3;

    public GameObject GameOverCanvas;
    #endregion


    public AudioSource bgmusic;
    public float hbonus;


    // ExpSlosions Set Up
    public ParticleSystem explosion2;

    void Start()
    {
        hbonus = PlayerPrefs.GetFloat("Hbonus", 1);
        playerHealth = 1000 * hbonus;
        maxHealth = playerHealth;
        HealthBar.value = maxHealth;
        acdCounter = 0;
        dmgmodifier = 1;
        HealthBar.maxValue = playerHealth;

        acdSkull1.SetActive(false);
        acdSkull2.SetActive(false);
        acdSkull3.SetActive(false);
    }

    void Update()
    {
        if (EnemyScript.isGameOver == true)
            playerHealth = 0;

        if (acdCounter == 2)
            acdSkull1.SetActive(true);

        else if (acdCounter == 4)
            acdSkull2.SetActive(true);

        else if (acdCounter == 6)
        {
            acdSkull3.SetActive(true);
            playerHealth = 0;
        }

        HealthBar.value = playerHealth;

        Nohealth();
        dmgModder();
        Pitcher();
    }

    void dmgModder()
    {
        if (ScoreScript.score < 100)
            dmgmodifier = 1;

        else if (ScoreScript.score < 200)
            dmgmodifier = (float)1.05;

        else if (ScoreScript.score < 300)
            dmgmodifier = (float)1.1;

        else if (ScoreScript.score < 400)
            dmgmodifier = (float)1.15;

        else if (ScoreScript.score < 500)
            dmgmodifier = (float)1.2;

        else
            dmgmodifier = (float)1.25;
    }

    void Nohealth()
    {
        if (playerHealth <= 0)
        {
            gameObject.SetActive(false);
            GameOverCanvas.SetActive(true);

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Direct Damage to Player 
        if (col.gameObject.tag == "Spike")
        {
            playerHealth -= spkDmg * dmgmodifier;

        }

        else if (col.gameObject.tag == "Pendulum")
        {
            playerHealth -= penDmg * dmgmodifier;

        }

        else if (col.gameObject.tag == "Saw")
        {
            playerHealth -= sawDmg * dmgmodifier;

        }

        else if (col.gameObject.tag == "Acid")
        {
            acdCounter += 1;
            playerHealth -= acdDmg * dmgmodifier;
        }

        else if (col.gameObject.tag == "Barrel")
        {
            playerHealth -= barDmg * dmgmodifier;
            explosion2.Stop();
            explosion2.Play();
            explosion2.startLifetime = explosion2.startLifetime;
        }

        else if (col.gameObject.tag == "Enemy")
        {
            playerHealth -= droidDmg * dmgmodifier;
            Destroy(col.gameObject);
        }
    }

    void Pitcher()
    {
        if (playerHealth > 800)
            bgmusic.pitch = 1f;

        else if (playerHealth > 600)
            bgmusic.pitch = 1.1f;

        else if (playerHealth > 400)
            bgmusic.pitch = 1.2f;

        else if (playerHealth > 200)
            bgmusic.pitch = 1.3f;

        else if (playerHealth > 100)
            bgmusic.pitch = 1.4f;

        else
            bgmusic.pitch = 1.5f;
    }

}
