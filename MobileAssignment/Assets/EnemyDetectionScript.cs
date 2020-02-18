using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionScript : MonoBehaviour
{
    public float distance;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }
    void Update()
    {

        Vector3 noAngle = transform.forward;
        Quaternion spreadAngle = Quaternion.AngleAxis(-15, new Vector3(0, 1, 0));
        Vector3 newVector = spreadAngle * noAngle;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if(hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            //Debug.Log("Hit Collider");
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("Ray hit the Player Collider");
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
           // Debug.Log("Is not hitting a Collider");
        }
    }
}
