using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpScript : MonoBehaviour
{
    public GameObject area1To2Gate1;
    public GameObject area1To2Gate2;
    public bool justWarped = false;
    float delay = 0.5f;
    float timer;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RightWrap" && justWarped == false)
        {
            transform.position = area1To2Gate2.transform.position;
            justWarped = true;
            timer = 0;
        }

        if (collision.gameObject.tag == "LeftWrap" && justWarped == false)
        {
            transform.position = area1To2Gate1.transform.position;
            justWarped = true;
            timer = 0;
        }
    }
    /*
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RightWrap" && justWarped == false)
        {
            transform.position = area1To2Gate2.transform.position;
            justWarped = true;
            timer = 0;
            //Debug.Log("Yee");
        }

        if (collision.gameObject.tag == "LeftWrap" && justWarped == false)
        {
            transform.position = area1To2Gate1.transform.position;
            justWarped = true;
            timer = 0;
        }
    }*/
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(timer > delay)
        {
            //Debug.Log("Exit trigger after warp?" + justWarped);
            justWarped = false;
        }
        
    }
}
