using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    public GameObject fakeBird;
    public GameObject realBird;

    private float fakeBirdTimer = 0f;
    public float fakeBirdMin = 10f;
    public float fakeBirdMax = 30f;
    private bool fakeBirdSpawned = false;
    private float fakeBirdSpawnTime = 0f;
    private bool spawned = false;
    private GameObject fakeBirdGO;

    private bool realBirdSpawned = false;
    public float realBirdMin = 2f;
    public float realBirdMax = 5f;
    private float realBirdTimer = 0f;
    private float realBirdSpawnTime = 0f;
    private GameObject realBirdGO;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        fakeBirdSpawnTime = Random.Range(fakeBirdMin, fakeBirdMax);
        realBirdSpawnTime = Random.Range(realBirdMin, realBirdMax);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        fakeBirdTimer += Time.deltaTime;
        if (fakeBirdTimer > fakeBirdSpawnTime && !fakeBirdSpawned)
        {
            if(!spawned)
            {
                fakeBirdGO = Instantiate(fakeBird);
                spawned = true;
            }
            if (fakeBirdGO.transform.position.x > 15)
            {
                realBirdSpawned = true;
                Destroy(fakeBirdGO);
                fakeBirdGO = null;
                fakeBirdSpawned = true;
                fakeBirdTimer = 0f;
                spawned = false;
            }
        }
        if (realBirdSpawned)
        {
            realBirdTimer += Time.deltaTime;
            if (realBirdTimer > realBirdSpawnTime)
            {
                realBirdGO = Instantiate(realBird, new Vector3(realBird.transform.position.x, realBird.transform.position.y + Random.Range(-3, 3), realBird.transform.position.z), realBird.transform.rotation);
                player.GetComponent<FindObstacles>().UpdateTarget(realBirdGO);
                realBirdSpawned = false;
                fakeBirdSpawned = false;
                realBirdTimer = 0f;
                realBirdGO = null;
                fakeBirdSpawnTime = Random.Range(fakeBirdMin, fakeBirdMax);
                realBirdSpawnTime = Random.Range(realBirdMin, realBirdMax);
            }
        }
    }
}
