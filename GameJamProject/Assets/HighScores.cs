using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    public string bestTime;
    public float threshold = 10000000000000f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Score");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        player = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    public void EndGame()
    {
        if (player != null)
        {
            var tracker = player.GetComponent<Score_Tracker>();
            if (tracker.totalTime < threshold)
            {
                threshold = tracker.totalTime;
                bestTime = tracker.displayTime;
            }
            
        }
    }
}
