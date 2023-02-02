using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Wiggle : MonoBehaviour
{
    private float timer = 0.8f;
    private float startTimer = 0.8f;
    private bool flip = false;
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0 && !flip)
        {
            GetComponent<SpriteRenderer>().flipX = true;

            flip = true;
            timer = startTimer;
        }

        else if (timer <0 && flip)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            flip = false;
            timer = startTimer;
        }
    }
}
