using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    public float windStrength;
    public float gustMin = 15f;
    public float gustMax = 30f;
    private float gustLength = 0f;
    [SerializeField] private float gustTimer = 0f;
    [SerializeField] private float windBlowingTimer = 0f;
    public float windBlowingMin = 2f;
    public float windBlowingMax = 6f;
    private float windBlowingLength = 0f;
    private bool gustSet = false;

    public ParticleSystem leftSideWind;
    public ParticleSystem rightSideWind;

    public GameObject leftWindObj;
    public GameObject rightWindObj;
    private GameObject player;

    public AudioClip[] windSounds;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        windBlowingLength = Random.Range(windBlowingMin, windBlowingMax);
        gustLength = Random.Range(gustMin, gustMax);

        leftSideWind.Stop();
        rightSideWind.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        /*leftSideWind.emissionRate = -windStrength;
        rightSideWind.emissionRate = windStrength;*/
        if (gustTimer > gustLength)
        {
            Debug.Log("Wind blow");
            if (!gustSet)
            {
                windStrength = Random.Range(-3f, 3f);
                gustSet = true;
            }
            else
            {
                player.transform.position = new Vector3(player.transform.position.x - windStrength * Time.deltaTime, player.transform.position.y, player.transform.position.z);
                windBlowingTimer += Time.deltaTime;
                if (!Cursor.visible)
                {
                    windBlowingTimer = windBlowingLength;
                }
                if (windBlowingTimer > windBlowingLength)
                {
                    windBlowingLength = Random.Range(windBlowingMin, windBlowingMax);
                    gustLength = Random.Range(gustMin, gustMax);
                    gustSet = false;
                    gustTimer = 0f;
                    windBlowingTimer = 0f;
                }
            }


        }
        else
        {
            gustTimer += Time.deltaTime;
        }

        if (gustSet)
        {
            if (windStrength >= 0)
            {
                if (!leftSideWind.isPlaying)
                {
                    leftSideWind.Play();
                    leftWindObj.GetComponent<AudioSource>().clip = windSounds[Random.RandomRange(0, windSounds.Length)];
                    leftWindObj.GetComponent<AudioSource>().Play();
                }
            }
            else if (windStrength < 0)
            {
                if (!rightSideWind.isPlaying)
                {
                    rightSideWind.Play();
                    rightWindObj.GetComponent<AudioSource>().clip = windSounds[Random.RandomRange(0, windSounds.Length)];
                    rightWindObj.GetComponent<AudioSource>().Play();
                }
            }    
        }
        else
        {
            leftSideWind.Stop();
            rightSideWind.Stop();
            leftWindObj.GetComponent<AudioSource>().Stop();
            rightWindObj.GetComponent<AudioSource>().Stop();
        }
    }
}
