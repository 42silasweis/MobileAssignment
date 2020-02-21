using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Vector3 touchPosition;
    public bool currentlyHolding = false;
    public float velocitySpeed;
    public float suspicion;
    float suspicionTimer;
    public float suspicionCoolDownDelay = 0.6f;
    Vector2 camerStopped;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cameraVelocity = GameObject.FindObjectOfType<CameraControl>().velocity;

        suspicionTimer += Time.deltaTime;
        for (int i = 0; i < Input.touchCount; i++)
        {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            Debug.DrawLine(transform.position, touchPosition, Color.red);
            if (Input.GetTouch(0).phase == TouchPhase.Moved && cameraVelocity == camerStopped || Input.GetTouch(0).phase == TouchPhase.Stationary && cameraVelocity == camerStopped)
            {
                currentlyHolding = true;
            }
            else
            {
                currentlyHolding = false;
            }
            //Debug.Log("Touching screen at: " + touchPosition);
        }
        velocitySpeed = GetComponent<Rigidbody2D>().velocity.magnitude;
        if (velocitySpeed >= 1.0f && currentlyHolding)
        {
            suspicion = velocitySpeed;
        }
        else if(suspicion > 0 && !currentlyHolding && suspicionTimer > suspicionCoolDownDelay)
        {
            
            suspicion -= 0.1f;
            if (suspicion < 0)
            {
                suspicion = 0;
            }
            suspicionTimer = 0;
        }
        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        //Vector2 moveDir = new Vector2(touchPosition.x - transform.position.x, touchPosition.y - transform.position.y);
        //GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
    }

}
