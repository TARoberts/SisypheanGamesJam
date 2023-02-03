using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMove : MonoBehaviour
{
    private List<GameObject> _parallaxObjects;
    [SerializeField] private float _speed;
    private bool falling;

    private void Start()
    {
        falling = true;
        _parallaxObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Parallax"));
    }

    private void Update()
    {
        if (falling)
        {
            int i = 0;
            foreach (GameObject go in _parallaxObjects)
            {
                Debug.Log((go.transform.localScale.x - 1) * (Random.Range(0, 2) * 2 - 1));
                go.transform.position += new Vector3((go.transform.localScale.x - 1) * ((i % 2) * 2 - 1) * _speed * Time.deltaTime * 0.1f, _speed * Time.deltaTime * go.transform.position.z, 0);
                i++;
                if (go.transform.position.y > 90)
                {
                    falling = false;
                }
            }
        }
    }
}
