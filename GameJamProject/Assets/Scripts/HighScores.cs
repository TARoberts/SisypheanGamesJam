using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    public string bestTime;
    public string currentTime;
    public float threshold = 1000000f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        
    }

    // Update is called once per frame

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Score");
        }
    }
    public void EndGame()
    {
        if (player != null)
        {
            var tracker = player.GetComponent<Score_Tracker>();
            if (tracker.totalTime < threshold)
            {
                threshold = tracker.totalTime;
                bestTime = tracker.displayTime;
                currentTime = tracker.displayTime;
            }
            else
            {
                currentTime = tracker.displayTime;
            }
            
        }
    }
}
