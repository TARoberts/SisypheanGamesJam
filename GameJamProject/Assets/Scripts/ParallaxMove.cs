using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMove : MonoBehaviour
{
    private List<GameObject> _parallaxObjects;
    private GameObject cam; 
    [SerializeField] private float _speed; 
    private void Start()
    {
        _parallaxObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Parallax"));
        cam = Camera.main.gameObject; 
    }

    private void Update()
    {
        foreach (GameObject go in _parallaxObjects)
        {
            go.transform.position += new Vector3(0,_speed * Time.deltaTime * go.transform.position.z, 0);
        }

        cam.transform.position += new Vector3(0, _speed * Time.deltaTime * 5, 0); 
    }
}
