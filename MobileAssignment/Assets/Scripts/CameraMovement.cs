using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 1;

    void Start()
    {

    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = (transform.up * speed);
    }
}
