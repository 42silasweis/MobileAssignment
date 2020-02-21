using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    Rigidbody2D rb;
    public Joystick joystick;
    public Vector2 velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //float moveX = Input.GetAxis("Horizontal");
        float x = joystick.Horizontal;
        float y = joystick.Vertical;
        velocity = GetComponent<Rigidbody2D>().velocity;
        Vector2 moveDir = new Vector2(x, y);
        velocity = moveDir * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
