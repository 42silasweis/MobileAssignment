using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public bool optionStatus = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionStatus == true)
            {
                GetComponent<Canvas>().enabled = true;
                Time.timeScale = 0;
            }
            else
            {
                GetComponent<Canvas>().enabled = false;
                Time.timeScale = 1;
            }
        }
    }
}