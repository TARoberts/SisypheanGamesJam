using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneOpen : MonoBehaviour
{

    [SerializeField] GameObject playerSprite;
    [SerializeField] Camera mainCamera;
    private FollowMouse _followMouse;
    private ParallaxMove _parallaxMove;

    [SerializeField] Transform dandStartPos;
    [SerializeField] Transform dandReleasePos;
    [SerializeField] float DandFloatSpeed;
    [SerializeField] float nightSpeed;
    private float timer; 


    private float _startTime;
    private float _journeyLength;
    private bool night;
    private bool _floatDone = false;
   
    [SerializeField] GameObject topScreenCollider;


    // Start is called before the first frame update
    void Start()
    {
        _followMouse = playerSprite.GetComponent<FollowMouse>();
        _parallaxMove = GameObject.Find("ParallaxController").GetComponent<ParallaxMove>();
        topScreenCollider.SetActive(false);

        _startTime = Time.time;
        _journeyLength = Vector3.Distance(dandStartPos.position, dandReleasePos.position);
        if (GameObject.FindGameObjectWithTag("Night")) 
        {
            night = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!_floatDone)
        {
            float _distCovered = (Time.time - _startTime) * DandFloatSpeed;
            float _fractOfJourney = _distCovered / _journeyLength;
            playerSprite.transform.position = Vector3.Lerp(dandStartPos.position, dandReleasePos.position, _fractOfJourney);

            if (playerSprite.transform.position == dandReleasePos.position)
            {
                _parallaxMove.SetFalling(true);
                _followMouse.SetMouseLock(false);
                //Debug.Log("Mouse Lock State: " + _followMouse.GetLockState());
                topScreenCollider.SetActive(true);
                _floatDone = true;
            }

            if (night)
            {
                Debug.Log(Mathf.Lerp(0, 200f / 255f, Time.deltaTime * nightSpeed));
                timer += Time.deltaTime;
                GameObject.FindGameObjectWithTag("Night").GetComponent<SpriteRenderer>().color = new Color(0, 0, 50f / 255f, Mathf.Lerp(0 ,220f/255f, timer * nightSpeed));
            }
        }
        
    }
}
