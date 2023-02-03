using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    HighScores scores;

    private void Start()
    {
        scores = GameObject.FindGameObjectWithTag("Manager").GetComponent<HighScores>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scores.EndGame();
            StartCoroutine(GameOver());
        }
        
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadSceneAsync("End Scene"); 
    }
}
