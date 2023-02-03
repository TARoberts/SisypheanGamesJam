using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - 5 * Time.deltaTime, transform.position.y, transform.position.z);

        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("Dead");
        }
    }
}
