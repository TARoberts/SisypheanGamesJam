using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;

    private Camera _camera;
    private Vector2 _screenBounds;
    private float _objectWidth;
    private float _objectHeight;

    [Header("Sway Settings")]
    [SerializeField] float swaySpeed = 2f;
    [SerializeField] float swayDistance = 0.2f;



    private void Start()
    {
        _camera = Camera.main;
        _screenBounds = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _camera.transform.position.z));
        _objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        _objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
 
    }

    // Update is called once per frame
    void Update()
    {
        var target3d = Input.mousePosition;

        target3d = Camera.main.ScreenToWorldPoint(target3d);
        var target = new Vector2(0f, 0f);

        target.x = target3d.x;
        target.y = target3d.y;
        
        float step = speed * Time.deltaTime;

        

        //Handle Swaying
        float newY = Mathf.Sin(Time.time * swaySpeed) * swayDistance + target.y;
        float newX = Mathf.Sin(Time.time * swaySpeed) * swayDistance + target.x;

        target.y = newY;
        target.x = newX;
        transform.position = Vector2.MoveTowards(transform.position, target, step);

        // Screen boundaries stop sprite going off screen
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, _screenBounds.x * -1 + _objectWidth, _screenBounds.x - _objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, _screenBounds.y * -1 + _objectHeight, _screenBounds.y - _objectHeight);

        transform.position = Vector2.MoveTowards(transform.position, viewPos, step);


    }
}
