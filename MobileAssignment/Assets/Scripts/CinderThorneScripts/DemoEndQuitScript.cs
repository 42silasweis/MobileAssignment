using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoEndQuitScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}
