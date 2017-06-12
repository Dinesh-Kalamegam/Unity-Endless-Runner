using UnityEngine;
using System.Collections;

public class Resetter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.SetInt("LP", 0);
            PlayerPrefs.SetInt("DP", 0);
            PlayerPrefs.SetInt("LA", 0);
            PlayerPrefs.SetInt("DA", 0);
            PlayerPrefs.SetInt("HighScore", 0);
            PlayerPrefs.Save();
        }
	}
}
