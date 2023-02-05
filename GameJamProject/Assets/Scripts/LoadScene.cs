using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    [SerializeField] string sceneToLoad;

    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;
    private bool _audioPlayed;
    private bool _playAudio;

    private void Start()
    {
        
        _audioPlayed = false;
        _playAudio = false;
        audioSource.clip = audioClip;
    }


    private void Update()
    {

        if (_playAudio)
        {
            StopAudio();
            audioSource.Play();
            StartCoroutine(WaitForSound(audioClip));
            _playAudio = false;
            _audioPlayed = true;
        }

        if (_audioPlayed)
        {
            SceneManager.LoadSceneAsync(sceneToLoad);
        }


    }

    public void LoadTheScene()
    {
        PlayClips();

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayClips()
    {
        _playAudio = true;
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

    IEnumerator WaitForSound(AudioClip clip)
    {

        yield return new WaitForSeconds(audioClip.length);
        //yield return new WaitUntil(() => audioSource.isPlaying == false);
    }
}
