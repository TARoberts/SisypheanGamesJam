using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMovement : MonoBehaviour
{
    
    [SerializeField] bool cursorVisible;


    void Start()
    {

        Cursor.lockState = CursorLockMode.Confined;

    }

    
    void Update()
    {
        if (!cursorVisible)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

        
    }
}
