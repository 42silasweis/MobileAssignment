using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float moveSpeed = 35;
    bool movingClockWise = false;
    bool movingCounterClockWise = true;
    bool startRotate = false;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Rotate();
        }
        if (startRotate)
        {
            if (movingCounterClockWise && !movingClockWise)
            {
                transform.Rotate(Vector3.forward * moveSpeed * Time.deltaTime);
                //Debug.Log(transform.rotation.z);
                if (transform.rotation.z >= 0.3420201f && movingCounterClockWise)
                {
                    movingClockWise = true;
                    movingCounterClockWise = false;
                    //Debug.Log("Booleans change");
                }
            }
            else if (movingClockWise && !movingCounterClockWise)
            {
                transform.Rotate(Vector3.forward * -moveSpeed * Time.deltaTime);
                if (transform.rotation.z <= -0.3420201f && movingClockWise)
                {
                    movingClockWise = false;
                    movingCounterClockWise = true;
                }
            }
        }
    }
    public void Rotate()
    {
        startRotate = true;
        
    }
    public void Stop()
    {
        startRotate = false;
    }
}
