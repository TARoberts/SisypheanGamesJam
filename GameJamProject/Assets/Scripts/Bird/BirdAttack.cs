using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAttack : MonoBehaviour
{
    private AudioSource screech;
    private bool screached = false;
    private float timer = 0f;
    private float screechTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        screech = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - 15 * Time.deltaTime, transform.position.y, transform.position.z);

        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }

        timer += Time.deltaTime;
        if (timer > screechTime && !screached)
        {
            screech.Play();
            screached = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.parent = transform;
            collision.GetComponent<FollowMouse>().enabled = false;
            collision.GetComponent<LockMovement>().enabled = false;
        }
    }
}
