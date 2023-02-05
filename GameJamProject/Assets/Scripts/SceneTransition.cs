using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] Transform camDefaultPos;
    [SerializeField] Transform camTransitionPos;
    [SerializeField] float camMoveSpeed = 5;
    private bool moveCamera = false;

    private float _startTime;
    private float _journeyLength;

    private List<string> sceneToLoad;
    [SerializeField] string[] scenesToLoad;

    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float fadeOutDuration;
    private float _fadeOutStart = 0;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
 
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {

        if (moveCamera)
        {
            // Canvas fade 
            float _progress = Time.time - _fadeOutStart;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, _progress / fadeOutDuration);

            // Camera movement
            float _distCovered = (Time.time - _startTime) * camMoveSpeed;
            float _fractOfJourney = _distCovered / _journeyLength;
            cam.transform.position = Vector3.Lerp(camDefaultPos.position, camTransitionPos.position, _fractOfJourney);
            if (cam.transform.position == camTransitionPos.position)
            {
                //Debug.Log("Cam moved to transition position");
                moveCamera = false;
                LoadScene();
            }
        }
    }

    public void EnableTransition()
    {
        cam = Camera.main;

        PlayAudioClip();
        WaitForSound(audioClip);
        

        _startTime = Time.time;
        _journeyLength = Vector3.Distance(camDefaultPos.position, camTransitionPos.position);

        _fadeOutStart = Time.time;
        canvasGroup.interactable = false;

        moveCamera = true;
    }

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(scenesToLoad[Random.Range(0, scenesToLoad.Length)]);   
    }

    public void PlayAudioClip()
    {
        audioSource.Stop();
        audioSource.Play();
    }

    IEnumerator WaitForSound(AudioClip clip)
    {
        yield return new WaitForSeconds(clip.length);
    }
}
