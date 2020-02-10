using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUp : MonoBehaviour
{
    int Lives;
    public Text liveText;
    void Start()
    {
        Lives = PlayerPrefs.GetInt("Lives");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "heart")
        {
            Lives++;
            PlayerPrefs.SetInt("Lives", Lives);
            liveText.text = "LIVES: " + Lives;
            Destroy(collision.gameObject);
        }
    }
    void Update()
    {

    }
}
