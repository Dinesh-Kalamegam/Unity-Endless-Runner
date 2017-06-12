using UnityEngine;
using System.Collections;

public class PlatformGeneration : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;
    public float DBMin;
    public float DBMax;

    public int ngplus;


    public GameObject[] thePlatforms;
    private float[] platformWidths;
    private int platformSelector;

    public float offmin;
    public float offmax;

    private float offset;

	// Use this for initialization
	void Start ()
    {

        platformWidths = new float[thePlatforms.Length];

        for (int i = 0; i < thePlatforms.Length; i++)
        {
            platformWidths[i] = thePlatforms[i].GetComponent<BoxCollider2D>().size.x;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(DBMin, DBMax);

            if (ScoreScript.score < 50)

             platformSelector = Random.Range(0, ngplus);

            else
             platformSelector = Random.Range(0, thePlatforms.Length);

            if (platformSelector != 6)
                offset = Random.Range(offmin, offmax);
            else
                offset = 0;

            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distanceBetween,  offset, transform.position.z);

            Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);
        }
	}
}
