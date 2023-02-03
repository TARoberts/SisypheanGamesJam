using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score_Tracker : MonoBehaviour
{
    private float _timer = 1f;
    private float _realTimer = 0f;

    [SerializeField] private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _realTimer += 1;
            text.text = _realTimer.ToString();
            _timer = 1f;         

        }
    }
}
