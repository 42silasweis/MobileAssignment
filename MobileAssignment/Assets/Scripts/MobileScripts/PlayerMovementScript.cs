using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementScript : MonoBehaviour
{
    public int currentLevel = 1;

    public float moveSpeed = 5.0f;
    public Vector3 touchPosition;
    public bool currentlyHolding = false;
    public float velocitySpeed;
    public float suspicion;
    float suspicionTimer;
    public float suspicionCoolDownDelay = 0f;
    Vector2 cameraStopped;
    public Slider suspicionSlider;
    // Start is called before the first frame update
    void Start()
    {
        suspicionSlider.maxValue = 1.8f;
        suspicionSlider.value = suspicion;
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
            if (Input.GetTouch(0).phase == TouchPhase.Moved && cameraVelocity == cameraStopped || Input.GetTouch(0).phase == TouchPhase.Stationary && cameraVelocity == cameraStopped)
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
        if (velocitySpeed >= suspicion && currentlyHolding)
        {
            suspicion = velocitySpeed;
            if(suspicion > suspicionSlider.value)
            {
                suspicionSlider.value = suspicion;
            }
        }
        if(suspicion > 0 && suspicionTimer > suspicionCoolDownDelay)// && !currentlyHolding
        {
            suspicion -= 0.02f;
            suspicionSlider.value = suspicion;

            if (suspicion < 0)
            {
                suspicion = 0;
                suspicionSlider.value = suspicion;
            }
            suspicionTimer = 0;
        }
        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        //Vector2 moveDir = new Vector2(touchPosition.x - transform.position.x, touchPosition.y - transform.position.y);
        //GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Exit")
        {
            switch (currentLevel)
            {
                case 1:
                    FindObjectOfType<LevelChanger>().FadeToLevel(3);
                    break;
                case 2:
                    FindObjectOfType<LevelChanger>().FadeToLevel(4);
                    break;
                case 3:
                    FindObjectOfType<LevelChanger>().FadeToLevel(5);
                    break;

            }
        }
    }

}
