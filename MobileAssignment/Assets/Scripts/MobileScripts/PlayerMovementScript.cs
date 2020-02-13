using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Vector3 touchPosition;
    public bool currentlyHolding = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            Debug.DrawLine(transform.position, touchPosition, Color.red);
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                currentlyHolding = true;
            }
            else
            {
                currentlyHolding = false;
            }
            //Debug.Log("Touching screen");
        }
        

        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        //Vector2 moveDir = new Vector2(touchPosition.x - transform.position.x, touchPosition.y - transform.position.y);
        //GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
    }
}
