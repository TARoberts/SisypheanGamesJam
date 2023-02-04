using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject[] obstacles;
    public Transform setTarget;
    private Vector3 directionToObstacle;
    float angleToObstacle;
    private float hideDistance = 2.5f;
    private float outOfRange = 8f;

    // Update is called once per frame
    void Update()
    {
        if(setTarget != null)
        {
            directionToObstacle = setTarget.position - transform.position;

            if (directionToObstacle.magnitude < hideDistance || directionToObstacle.magnitude > outOfRange)
            {
                SetChildActive(false);
            }
            else
            {
                SetChildActive(true);

                angleToObstacle = Mathf.Atan2(directionToObstacle.y, directionToObstacle.x) * Mathf.Rad2Deg + 270;
                transform.rotation = Quaternion.AngleAxis(angleToObstacle, Vector3.forward);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetTarget(Transform target)
    {
        setTarget = target; 
    }
    void SetChildActive(bool isActive)
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }
}
