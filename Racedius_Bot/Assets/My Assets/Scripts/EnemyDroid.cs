using UnityEngine;
using System.Collections;

public class EnemyDroid : MonoBehaviour
{
    // speed in the y axis 
    public float Yspeed;

    void Update()
    {
        // translate the gear by speed * time.delta time in the x axis
        // Time.deltaTime used to avoid the movement being framerate dependent 

        transform.Translate(new Vector3(0, Yspeed, 0 * Time.deltaTime));
    }

    // What happens if the enemy gear collides with something 
    void OnCollisionEnter2D(Collision2D col)
    {
        // if it collides with object tagged block 
        if (col.gameObject.tag == "Block")
        {
            //reverse direction 
            Yspeed *= -1;
        }
    }
}