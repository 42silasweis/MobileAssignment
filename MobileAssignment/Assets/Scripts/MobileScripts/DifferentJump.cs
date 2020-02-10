using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentJump : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody2D rb;
    float y;
    GameObject camera;
    float bulletspeed;
    Vector2 velocity;
    void Start()
    {
        float y = 1;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (camera == null)
        {
            camera = GameObject.FindGameObjectWithTag("MainCamera");
        }
        velocity = camera.GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = (transform.up * speed);
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, velocity.y);
    }
}
