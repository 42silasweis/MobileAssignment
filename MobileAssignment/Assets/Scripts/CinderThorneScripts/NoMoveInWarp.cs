using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMoveInWarp : MonoBehaviour
{
    public bool playerCanMove;
    float timer;
    float delay = 1.0f;

    void Start()
    {
        playerCanMove = true;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(playerCanMove && timer > delay)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
