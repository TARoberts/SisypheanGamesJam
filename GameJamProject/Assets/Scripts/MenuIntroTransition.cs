using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuIntroTransition : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] Transform camDefaultPos;
    [SerializeField] Transform camTransitionPos;
    [SerializeField] float camMoveSpeed = 5;
    private bool moveCamera = false;

    private float _startTime;
    private float _journeyLength;

    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float fadeInDuration;
    private float _fadeInStart = 0;
    private bool _fadeInUI;

    // Start is called before the first frame update
    void Start()
    {
        _fadeInUI = false;
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0;
        EnableTransition();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCamera)
        {
            
            // Camera movement
            float _distCovered = (Time.time - _startTime) * camMoveSpeed;
            float _fractOfJourney = _distCovered / _journeyLength;
            cam.transform.position = Vector3.Lerp(camTransitionPos.position, camDefaultPos.position, _fractOfJourney);
            if (cam.transform.position == camDefaultPos.position)
            {
                //Debug.Log("Cam moved to transition position");
                moveCamera = false;
                canvasGroup.interactable = true;
                _fadeInUI = true;
                _fadeInStart = Time.time;

            }
        }

        if (_fadeInUI)
        {
            
            // Canvas fades in after camera stops 
            float _progress = Time.time - _fadeInStart;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, _progress / fadeInDuration);

        }
    }

    public void EnableTransition()
    {
        cam = Camera.main;
        _startTime = Time.time;

        _journeyLength = Vector3.Distance(camTransitionPos.position, camDefaultPos.position);

        
        moveCamera = true;
    }
}
