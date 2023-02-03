using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score_Tracker : MonoBehaviour
{
    private float _timer = 1f;
    private float _realTimerSeconds = 0f;
    private float _realTimer10s = 0f;
    private float _realTimerMinutes = 0f;
    private string displayTime;

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
            displayTime = null;
            if (_realTimerSeconds < 9)
            {
                _realTimerSeconds += 1;
            }
            else if (_realTimerSeconds == 9)
            {
                _realTimerSeconds = 0;

                if (_realTimer10s < 5)
                {
                    _realTimer10s++;
                }
                
                else if (_realTimer10s == 5)
                {
                    _realTimer10s = 0;
                    _realTimerMinutes++;
                }
            }

            displayTime += _realTimerMinutes.ToString();
            displayTime += ":";
            displayTime += _realTimer10s.ToString();
            displayTime += _realTimerSeconds.ToString();

            text.text = displayTime;
            _timer = 1f;         

        }
    }
}
