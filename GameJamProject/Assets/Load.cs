using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    [SerializeField] private AudioSource _BGM;
    [SerializeField] private Image _whiteOut, _button;
    [SerializeField] private bool _fade = false;

    private void Update()
    {
        if (_fade)
        {
            _whiteOut.color += new Color(1, 1, 1, 1 * Time.deltaTime);
            _button.color -= new Color(_button.color.r, _button.color.g, _button.color.b, 1 * Time.deltaTime);
            _BGM.volume -= 0.1f*Time.deltaTime;
        }
    }
    public void LoadGame()
    {
        StartCoroutine(TransitionTimer());
    }

    IEnumerator TransitionTimer()
    {
        _fade = true;
        yield return new WaitForSeconds (2.0f);
        SceneManager.LoadSceneAsync("MainScene");
    }
}
