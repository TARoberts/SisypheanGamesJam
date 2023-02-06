using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private HighScores scores;

    private void Start()
    {
        scores = GameObject.FindGameObjectWithTag("Manager").GetComponent<HighScores>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scores.EndGame();
            StartCoroutine(Grow(collision.gameObject));
            
            StartCoroutine(GameOver());
        }
        
    }

    IEnumerator Grow(GameObject player)
    {
        player.GetComponent<Grow>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(5.0f);
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<Grow>().enabled = false;
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadSceneAsync("End Scene"); 
    }
}
