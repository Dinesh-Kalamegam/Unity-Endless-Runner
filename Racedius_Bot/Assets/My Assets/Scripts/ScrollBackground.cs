using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour {

    public float speed = 0.5f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Create a new Vector in the (x,y) Plane 
        // The x offset is the x coordinate * speed which is public changeable (0.5 default)
        // The y offset is 0

        Vector2 offset = new Vector2(Time.time * speed,0);


        // The renderer component of the background has its main texture shifted by offset
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
