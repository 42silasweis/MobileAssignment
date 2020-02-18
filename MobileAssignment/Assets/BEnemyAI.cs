using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BEnemyAI : MonoBehaviour
{
    public float stopDistance = 0.35f;
    public Transform target;
    public float speed = 4f;
    public float nextWayPointDistance = 1f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    public bool runToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        Vector3 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed;// * Time.deltaTime;
        direction.z = transform.position.z;
        //rb.AddForce(force);
        Vector2 moveDir = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        if (moveDir.magnitude > stopDistance && runToPlayer)
        {
            //rb.velocity = force;
            rb.AddForce(force);
            //Debug.Log("Is supposed to move");
        }
        else if (moveDir.magnitude < stopDistance)
        {
            rb.velocity = new Vector2 (0, 0); 
            //Debug.Log("Is not supposed to move");
        }
        

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWayPointDistance)
        {
            currentWaypoint++;
        }
    }
}
