using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObstacles : MonoBehaviour
{
    public List<GameObject> obstacles;
    public GameObject[] targets;
    public GameObject targetIndicator;

    private void Start()
    {
        obstacles.AddRange(GameObject.FindGameObjectsWithTag("Obstacles"));
        foreach (GameObject obstacle in obstacles)
        {
            //if(obstacles[].Count)
            GameObject _targetIndicator = Instantiate(targetIndicator, Vector3.zero, Quaternion.identity);
            _targetIndicator.transform.parent = this.gameObject.transform;
            _targetIndicator.GetComponent<TargetController>().SetTarget(obstacle.transform);
        }
    }
    public void UpdateTarget(GameObject targetObj)
    {
        GameObject _targetIndicator = Instantiate(targetIndicator, Vector3.zero, Quaternion.identity);
        _targetIndicator.transform.parent = this.gameObject.transform;
        _targetIndicator.GetComponent<TargetController>().SetTarget(targetObj.transform);
    }
}
