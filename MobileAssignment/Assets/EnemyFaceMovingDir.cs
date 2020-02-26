using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFaceMovingDir : MonoBehaviour
{
    public float rotationSpeed = 2.0f;

    bool isMoving;
    void Update()
    {
        //This function is to make the player sprite face the direction it is moving
        //I believe it requires the sprite to be a Child of the main Player/Object and rotated -90 degrees if the sprite is facing in the UP position
        //This is due to the Vector being a .forward which is necessary as that is the Z rotation axis that makes the sprite "rotate" and not flip like paper mario
        Vector3 moveDirection = GetComponent<Rigidbody2D>().velocity;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.fixedDeltaTime * rotationSpeed);
        }
        if (GetComponentInParent<Rigidbody2D>().velocity.magnitude > 0.1f)
        {
            isMoving = true;
        }
        else if (GetComponentInParent<Rigidbody2D>().velocity.magnitude < 0.1f && GetComponentInParent<Rigidbody2D>().velocity.magnitude > -0.1f)
        {
            isMoving = false;
        }
        GetComponentInChildren<Animator>().SetBool("isMoving", isMoving);
    }
}
