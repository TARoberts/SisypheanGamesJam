using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSwoop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + 10 * Time.deltaTime, transform.position.y, transform.position.z);
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
