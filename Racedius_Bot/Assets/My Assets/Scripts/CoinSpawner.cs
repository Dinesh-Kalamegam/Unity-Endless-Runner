using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{

    // creates an array to whic items can be added to via the inspector
    public GameObject[] coinpool;

    public int GIndex;
    public int YIndex;
    public int BIndex;

    void Start()
    { 
        Spawn();
    }

    void Spawn()
    {

        if (ScoreScript.score < 250)
            Instantiate(coinpool[0], ((transform.position)), Quaternion.identity);

        else if (ScoreScript.score < 750)
            Instantiate(coinpool[1], ((transform.position)), Quaternion.identity);

        else
            Instantiate(coinpool[2], ((transform.position)), Quaternion.identity);


    }
}
