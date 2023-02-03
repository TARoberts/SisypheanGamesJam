using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs_block_script : MonoBehaviour
{

    GameObject player_char = null;

    // Update is called once per frame
    void Update()
    {
        if(player_char != null)
        {
            Debug.Log("De-parent");

            float _dist = Vector2.Distance(transform.position, player_char.transform.position);


            if (_dist > 2)
            {
                player_char.GetComponent<FollowMouse>()._obsticle_hit = false;
                player_char.transform.parent = null;
                player_char = null;
            }

        }

        if(transform.position.y > Screen.height)
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
        if (collision.transform.tag == "Player")
        {
            FollowMouse _FM_script = collision.GetComponent<FollowMouse>();
            _FM_script._obsticle_hit = true;

            collision.transform.parent = transform;

            player_char = collision.gameObject;
        }
    }

}
