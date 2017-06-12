using UnityEngine;

public class AudioGenerator : MonoBehaviour {

    // make an arrary intended to be filled with audio prefabs in the inspector 
    public GameObject [] audiogen;

    // Use this for initialization
    void Start()
    {
        // When scene loads call the function and execute it 
        Spawn();

    }

    void Spawn()
    {
        // choose a random gameobject in audiogen array and spawn it at the position of spawn object with no rotation 
        Instantiate(audiogen [Random.Range(0, audiogen.Length)], transform.position, Quaternion.identity);
    }

}
