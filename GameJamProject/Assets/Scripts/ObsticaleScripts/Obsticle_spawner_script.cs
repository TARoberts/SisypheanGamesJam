using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Obsticle_spawner_script : MonoBehaviour
{
    [Header("spawn_paramters")]
    public float _spawn_time;
    public Score_Tracker _score_tracker;

    public GameObject[] _cloud_prefabs;
    public GameObject[] _brach_prefabs;
    public GameObject[] _bush_prefabs;

    public bool _use_spawner;

    public float _current_timer;

    private Camera _camera;

    public float zoneTimer;

    // Start is called before the first frame update
    void Start()
    {
        _current_timer = _spawn_time;
        _camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_use_spawner)
        {
            zoneTimer += Time.deltaTime;
            if (_current_timer <= 0)
            {
                _current_timer = _spawn_time;
                float _time = _score_tracker.totalTime;

                Vector2 _spawn_location = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _camera.transform.position.z));

                if (zoneTimer > 5 && zoneTimer < 25)
                {
                    //cloud layer

                    _spawn_location = new Vector2(Random.Range(-_spawn_location.x/2, _spawn_location.x/2), -10);
                    int _spawn_index = Random.Range(0, _cloud_prefabs.Length);
                    Instantiate(_cloud_prefabs[_spawn_index], _spawn_location, new Quaternion());

                }
                else if (zoneTimer > 25 && zoneTimer < 50)
                {
                    //branch layer
                    int _side = Random.Range(0, 2);
                    int _spawn_index = Random.Range(0, _brach_prefabs.Length);

                    GameObject spawned_obj = Instantiate(_brach_prefabs[_spawn_index], _spawn_location, new Quaternion());

                    if (_side == 0)
                    {
                        //left side
                        _spawn_location = new Vector2(-_spawn_location.x / 2, -10);
                    }
                    else
                    {
                        //right side (flip sprite place on screen width max
                        _spawn_location = new Vector2(_spawn_location.x / 2, -10);
                        spawned_obj.transform.localScale = new Vector2(-spawned_obj.transform.localScale.x, spawned_obj.transform.localScale.y);
                    }

                    spawned_obj.transform.position = _spawn_location;
                }
                else if (zoneTimer >= 50)
                {
                   /* //bush layer??
                    _spawn_location = new Vector2(Random.Range(0, _spawn_location.x), -10);
                    int _spawn_index = Random.Range(0, _bush_prefabs.Length);
                    Instantiate(_bush_prefabs[_spawn_index], _spawn_location, new Quaternion());
                   */
                }

                
            }
            else
            {
                _current_timer -= Time.deltaTime;
            }
        }
    }
}
