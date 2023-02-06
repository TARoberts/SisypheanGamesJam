using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Clouds : MonoBehaviour
{
    [SerializeField] Transform[] spawns;
    [SerializeField] float startTimer = 4.0f;
    [SerializeField] private GameObject[] clouds;
    private float _timer;

    private Vector3 _randomSpawnPos;

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
            Instantiate(clouds[cloudid], GetRandomSpawnPos(spawns[0], spawns[1]), spawns[spawnid].rotation);
        }

        
    }

    private Vector3 GetRandomSpawnPos(Transform pos1, Transform pos2)
    {
        Vector3 difference = pos1.position - pos2.position;
        Vector3 new_diff = difference * Random.Range(0.0f, 1.0f);

        _randomSpawnPos = pos1.position - new_diff;

        return _randomSpawnPos;
    }

    
}
