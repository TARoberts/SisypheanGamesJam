using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCloud : MonoBehaviour
{
    private float lifeTimer = 20.0f;
    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        transform.position += new Vector3(0.5f*Time.deltaTime,0, 0);
        if (lifeTimer < 0)
        {
            this.enabled = false;
            Destroy(this.gameObject);
        }
    }
}
