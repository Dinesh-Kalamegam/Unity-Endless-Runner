using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // The object the camera is to follow (the player) 
    public GameObject targetObject;

    // how far the camera is from the object 
    private float distanceToTarget;


	void Start ()
    {
        // calculates how far the camera is from the player
        distanceToTarget = transform.position.x - targetObject.transform.position.x;

    }

    void Update () {

        // the x coordinate of the player 
        float targetObjectX = targetObject.transform.position.x;

        // The newCameraPosition in the (x,y,z) plane is equal transform.position
        Vector3 newCameraPosition = transform.position;

        // sets the new camera position of the camera 
        newCameraPosition.x = targetObjectX +distanceToTarget;

        //  sets the value of transform.position to  newCameraPosition
        transform.position = newCameraPosition;
	}
}
