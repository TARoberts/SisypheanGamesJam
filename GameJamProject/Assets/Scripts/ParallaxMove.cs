using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMove : MonoBehaviour
{
    private List<GameObject> _parallaxObjects;
    private List<Vector3> _pObjsStartPos;
    [SerializeField] private float _speed;
    private float _acceleration = 0.00025f;
    private float _timer = 1f;
    private bool falling;

    private void Start()
    {
        falling = true;
        _parallaxObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Parallax"));
        _pObjsStartPos = new List<Vector3>();
        foreach (GameObject go in _parallaxObjects)
        {
            _pObjsStartPos.Add(go.transform.position);
        }
    }

    private void Update()
    {
        if (falling)
        {
            _timer -= Time.deltaTime;

            if (_timer < 0)
            {
                _timer = 1f;
                _speed += _acceleration;
            }

            int i = 0;
            foreach (GameObject go in _parallaxObjects)
            {
                Debug.Log((go.transform.localScale.x - 1) * (Random.Range(0, 2) * 2 - 1));
                go.transform.position += new Vector3((go.transform.localScale.x - 1) * ((i % 2) * 2 - 1) * _speed * Time.deltaTime * 0.1f, _speed * Time.deltaTime * go.transform.position.z, 0);
                i++;
                if (go.transform.position.y > 75)
                {
                    falling = false;  
                }
            }
        }
    }

    public void ResetCam()
    {

        for (int i = 0; i < _parallaxObjects.Count; i++)
        {
            _parallaxObjects[i].transform.position = _pObjsStartPos[i];
        }
    }
}
