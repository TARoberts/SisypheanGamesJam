using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSwoop : MonoBehaviour
{
    private AudioSource screech;
    private bool screached = false;
    private float timer = 0f;
    private float screechTime = 0.1f;
    // Start is called before the first frame update
    
    void Awake()
    {
        screech = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + 10 * Time.deltaTime, transform.position.y, transform.position.z);

        timer += Time.deltaTime;
        if(timer > screechTime && !screached)
        {
            screech.Play();
            screached = true;
        }
    }

    // potentially be implemented after game finished
    bool RandomDirection()
    {
        if (Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }
}
