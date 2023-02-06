using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public GameObject growingDandelion;
    public bool grown = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!grown)
        {
            Instantiate(growingDandelion, transform.position, transform.rotation);
            grown = true;
        }

    }
}
