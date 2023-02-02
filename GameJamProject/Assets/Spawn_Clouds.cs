using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Clouds : MonoBehaviour
{
    [SerializeField] Transform[] spawns;
    [SerializeField] float startTimer = 4.0f;
    [SerializeField] private GameObject[] clouds;
    private float _timer;

    private void Start()
    {
        _timer = startTimer;
    }


    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            _timer = startTimer;

            int cloudid = Random.Range(0, 2);
            Debug.Log(cloudid);
            int spawnid = Random.Range(0, 2);
            Instantiate(clouds[cloudid], spawns[spawnid].position, spawns[spawnid].rotation);
        }
    }
}
