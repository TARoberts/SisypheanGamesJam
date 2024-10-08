using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    private string highScore, currentScore;
    public TextMeshProUGUI recordText, currentText;
    private float _timer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        var scores = GameObject.FindGameObjectWithTag("Manager");

        if (scores != null)
        {
            highScore = scores.GetComponent<HighScores>().bestTime;
            currentScore = scores.GetComponent<HighScores>().currentTime;

            recordText.text = highScore;
            currentText.text = currentScore;
        }
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            
        }

    }
}
