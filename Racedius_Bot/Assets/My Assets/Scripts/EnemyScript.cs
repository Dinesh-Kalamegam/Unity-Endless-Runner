using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    // the movement speed of the enemy gear; 
    public float moveSpeed = 1.0f;
    public Rigidbody2D rb;
    public static bool isGameOver;
    public Camera mcamera;
    public GameObject GameOverCanvas;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // translate the gear by speed * time.delta time in the x axis
        // Time.deltaTime used to avoid the movement being framerate dependent 
        rb.velocity = new Vector2 (moveSpeed,0);
        ;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if it collides with the player its gameover
        // this is always when the player falls off the level 

        if (other.tag == "Player")
        {
            isGameOver = true;
        }

        }
    }