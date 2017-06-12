using UnityEngine;
using System.Collections;


public class SpawnScript : MonoBehaviour
{
    // creates an array to whic items can be added to via the inspector
    public GameObject[] obj;

    // The minimum amount of time before a new object is spawned
    public int spawnMin = 1;

    // The maximum amount of time before a new object is spawned 
    public int spawnMax = 2;

    // A random number that would instantiate an object
    public int RNumber;


    // A gameobject that will get boxcollider2D
    private GameObject instobj;

    void Start()
    {
        // When the game starts call the spawn function
        // As the spawn function is INVOKED in a time period  Spawn() is not in Update()

        Spawn();
    }

    void Spawn()
    {
        // Create a clone (random object in the array, at the position of spawn object, no rotation) 

        RNumber = Random.Range(0, obj.Length);

        Instantiate(obj[RNumber], ((transform.position)), Quaternion.identity);

        instobj = (GameObject)Instantiate(obj[RNumber], ((transform.position)), Quaternion.identity);

        // Call the function named Spawn at any time between spawnMin and spawnMax 
        // THIS INVOKE CALL MAKES the game endlesss

        Invoke("Spawn", (Random.Range(spawnMin, spawnMax)));
    }

}
