using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        var target3d = Input.mousePosition;

        target3d = Camera.main.ScreenToWorldPoint(target3d);
        var target = new Vector2(0f, 0f);

        target.x = target3d.x;
        target.y = target3d.y;


        float maxX = 2.3f;
        float maxY = 4.4f;

        if (target.x > maxX)
        {
            target.x = maxX;
        }

        else if (target.x <  -maxX)
        {
            target.x = -maxX;
        }

        if (target.y > maxY)
        {
            target.y = maxY;
        }

        else if (target.y < -maxY)
        {
            target.y = -maxY;
        }

        
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
}
