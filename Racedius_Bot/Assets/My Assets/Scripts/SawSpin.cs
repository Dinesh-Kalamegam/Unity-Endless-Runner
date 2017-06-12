using UnityEngine;
using System.Collections;

public class SawSpin : MonoBehaviour {

    // the movement speed of the enemy gear; 
    public float moveSpeed = 1.0f;


    void Update()
    {
        // translate the gear by speed * time.delta time in the x axis
        // Time.deltaTime used to avoid the movement being framerate dependent 
        if (gameObject.tag == "Red")
        transform.Translate(new Vector3(moveSpeed, 0, 0 * Time.deltaTime));
    }
}
