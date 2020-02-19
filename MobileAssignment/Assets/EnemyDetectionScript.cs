using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionScript : MonoBehaviour
{
    public float distance;
    public bool playerIsInSight = false;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }
    void Update()
    {
        // Numbering starts from top to bottom meaning top starts at 1

        Vector3 noAngle = transform.right; //This and the next two lines is for Raycast 1 offset at an angle of -15 from the transform.right position
        Quaternion spreadAngle = Quaternion.AngleAxis(6, new Vector3(0, 0, 1));
        Vector3 newVector = spreadAngle * noAngle;

        Quaternion spreadAngle2 = Quaternion.AngleAxis(354, new Vector3(0, 0, 1)); //This and the one below it is for Raycast 3 offset at an angle of 15 from the transform.right position
        Vector3 newVector2 = spreadAngle2 * noAngle;

        Quaternion spreadAngle3 = Quaternion.AngleAxis(14, new Vector3(0, 0, 1)); //This and the one below it is for Raycast 4 offset at an angle of 15 from the transform.right position
        Vector3 newVector3 = spreadAngle3 * noAngle;

        Quaternion spreadAngle4 = Quaternion.AngleAxis(346, new Vector3(0, 0, 1)); //This and the one below it is for Raycast 5 offset at an angle of 15 from the transform.right position
        Vector3 newVector4 = spreadAngle4 * noAngle;


        RaycastHit2D hitInfo1 = Physics2D.Raycast(transform.position, newVector, distance);
        RaycastHit2D hitInfo2 = Physics2D.Raycast(transform.position, transform.right, distance); // This is the center Raycast
        RaycastHit2D hitInfo3 = Physics2D.Raycast(transform.position, newVector2, distance);
        RaycastHit2D hitInfo4 = Physics2D.Raycast(transform.position, newVector3, distance);
        RaycastHit2D hitInfo5 = Physics2D.Raycast(transform.position, newVector4, distance);


        if (hitInfo1.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo1.point, Color.red);
            //Debug.Log("Hit Collider");
            if (hitInfo1.collider.CompareTag("Player"))
            {
                //Debug.Log("Ray hit the Player Collider");
                if (!playerIsInSight)
                {
                    playerIsInSight = true;
                }
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + newVector * distance, Color.green);
        }


        if (hitInfo2.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo2.point, Color.red);
            //Debug.Log("Hit Collider");
            if (hitInfo2.collider.CompareTag("Player"))
            {
                //Debug.Log("Ray hit the Player Collider");
                if (!playerIsInSight)
                {
                    playerIsInSight = true;
                }
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
        }


        if (hitInfo3.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo3.point, Color.red);
            //Debug.Log("Hit Collider");
            if (hitInfo3.collider.CompareTag("Player"))
            {
                //Debug.Log("Ray hit the Player Collider");
                if (!playerIsInSight)
                {
                    playerIsInSight = true;
                }
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + newVector2 * distance, Color.green);
        }

        if (hitInfo4.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo4.point, Color.red);
            //Debug.Log("Hit Collider");
            if (hitInfo4.collider.CompareTag("Player"))
            {
                //Debug.Log("Ray hit the Player Collider");
                if (!playerIsInSight)
                {
                    playerIsInSight = true;
                }
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + newVector3 * distance, Color.green);
        }

        if (hitInfo5.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo5.point, Color.red);
            //Debug.Log("Hit Collider");
            if (hitInfo5.collider.CompareTag("Player"))
            {
                //Debug.Log("Ray hit the Player Collider");
                if (!playerIsInSight)
                {
                    playerIsInSight = true;
                }
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + newVector4 * distance, Color.green);
        }



        if (playerIsInSight)
        {
            if(hitInfo1.collider.tag != ("Player") && hitInfo2.collider.tag != ("Player") && hitInfo3.collider.tag != ("Player") && hitInfo4.collider.tag != ("Player") && hitInfo5.collider.tag != ("Player"))
            {
                playerIsInSight = false;
            }
        }


        /*
        if (hitInfoTop.collider != null || hitInfoMiddle.collider != null || hitInfoBottom.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfoTop.point, Color.red);
            Debug.DrawLine(transform.position, hitInfoMiddle.point, Color.red);
            Debug.DrawLine(transform.position, hitInfoBottom.point, Color.red);

            if (hitInfoTop.collider.CompareTag("Player") || hitInfoMiddle.collider.CompareTag("Player") || hitInfoBottom.collider.CompareTag("Player"))
            {
                Debug.Log("Ray hit the Player Collider");
                if (!playerIsInSight)
                {
                    playerIsInSight = true;
                }
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + newVector * distance, Color.green);
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            Debug.DrawLine(transform.position, transform.position + newVector2 * distance, Color.green);

            if (playerIsInSight)
            {
                playerIsInSight = false;
            }
        }
        


        if (hitInfoTop.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfoTop.point, Color.red);
            //Debug.Log("Hit Collider");
            if (hitInfoTop.collider.CompareTag("Player"))
            {
                Debug.Log("Ray hit the Player Collider");
                if (!playerIsInSight)
                {
                    playerIsInSight = true;
                }
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + newVector * distance, Color.green);
            // Debug.Log("Is not hitting a Collider");
            if (playerIsInSight && hitInfoMiddle.collider == null || hitInfoBottom.collider == null)
            {
                playerIsInSight = false;
            }
        }
        

        if (hitInfoMiddle.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfoMiddle.point, Color.red);
            //Debug.Log("Hit Collider");
            if (hitInfoMiddle.collider.CompareTag("Player"))
            {
                Debug.Log("Ray hit the Player Collider");
                if (!playerIsInSight)
                {
                    playerIsInSight = true;
                }
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            // Debug.Log("Is not hitting a Collider");
            if (playerIsInSight && hitInfoTop.collider == null || hitInfoBottom.collider == null)
            {
                playerIsInSight = false;
            }
        }
        

        if (hitInfoBottom.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfoBottom.point, Color.red);
            //Debug.Log("Hit Collider");
            if (hitInfoBottom.collider.CompareTag("Player"))
            {
                Debug.Log("Ray hit the Player Collider");
                if (!playerIsInSight)
                {
                    playerIsInSight = true;
                }
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + newVector2 * distance, Color.green);
            // Debug.Log("Is not hitting a Collider");
            if (playerIsInSight && hitInfoTop.collider == null || hitInfoMiddle.collider == null)
            {
                playerIsInSight = false;
            }
        }
        */
    }
}
