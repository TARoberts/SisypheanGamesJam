using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs_block_script : MonoBehaviour
{
    GameObject player_char = null;
    [SerializeField] private Obsticle_spawner_script manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Obsticle_spawner_script>();
    }
    // Update is called once per frame
    void Update()
    {
        if (manager.zoneTimer < 5f)
        {
            Destroy(this.gameObject);
        }

        
         if(player_char != null)
        {
            Vector3 _move_direction = player_char.transform.position - transform.position;

            player_char.transform.position = Vector2.MoveTowards(player_char.transform.position, (player_char.transform.position + (_move_direction * 20)), 2f * Time.deltaTime);
            //player_char.transform.position = player_char.transform.position. + (_move_direction * 2) * Time.deltaTime;
        }
        

        if (transform.position.y > Screen.height)
        {
            Destroy(transform);
        }
        else
        {
            transform.position = new Vector2(transform.position.x , transform.position.y + (1.4f*Time.deltaTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<FollowMouse>() != null)
        {
            FollowMouse _FM_script = collision.GetComponent<FollowMouse>();
            _FM_script._obsticle_hit = true;

            //collision.transform.parent = transform;

            player_char = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<FollowMouse>() != null)
        {
            FollowMouse _FM_script = collision.GetComponent<FollowMouse>();
            _FM_script._obsticle_hit = false;

            //collision.transform.parent = null;

            player_char = null;
        }
    }

}
