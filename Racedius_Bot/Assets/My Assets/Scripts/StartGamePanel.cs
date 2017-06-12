using UnityEngine;
using System.Collections;

public class StartGamePanel : MonoBehaviour {

    public bool start;

	// Use this for initialization
	void Start () {
	
	}
	

	void Update () {
        if (start == true)
        {
            Time.timeScale = 0f;
            gameObject.SetActive(true);
        }

        else
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
	}

    public void OKbutton()
    {
        gameObject.SetActive(true);
    }
}

