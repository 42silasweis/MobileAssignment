using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPatrolFullCustom : MonoBehaviour
{
    public bool patrolInOrder = false;

    public float stopDistance = 0.35f;
    float moveDirDist;
    //public Transform player;
    public Transform target;
    public Transform[] patrolLocations;

    float randomSelectedLocation;

    public float speed = 4f;
    public float patrolSpeed = 2f;
    float noiseLevel;

    public float noiseCauseSuspicionLevel = 1.0f;
    bool enemySeesPlayer;

    public float nextWayPointDistance = 1f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    Vector2 moveDir;

    public float minWaitForThisLong = 3;
    public float maxWaitForThisLong = 6;
    public float randomWaitTime;
    float waitTimer;
    public bool canPatrol;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);

        randomWaitTime = Random.Range(minWaitForThisLong, maxWaitForThisLong);
        if (patrolInOrder)
        {
            randomSelectedLocation = 1;
        }
        else
        {
            randomSelectedLocation = Random.Range(1, patrolLocations.Length + 1);
        }
        
    }
    void UpdatePath()
    {
        if (seeker.IsDone() && target != null)
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

    void Update()
    {
        canPatrol = GameObject.FindObjectOfType<BEnemyAI>().canPatrol;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        waitTimer += Time.deltaTime;
        noiseLevel = GameObject.FindObjectOfType<BEnemyAI>().noiseLevel;

        if (canPatrol)
        {
            switch (randomSelectedLocation)
            {
                case 1:
                    target = patrolLocations[0];
                    break;
                case 2:
                    target = patrolLocations[1];
                    break;
                case 3:
                    target = patrolLocations[2];
                    break;
                case 4:
                    target = patrolLocations[3];
                    break;
                case 5:
                    target = patrolLocations[4];
                    break;
                case 6:
                    target = patrolLocations[5];
                    break;
                case 7:
                    target = patrolLocations[6];
                    break;
                case 8:
                    target = patrolLocations[7];
                    break;
                case 9:
                    target = patrolLocations[8];
                    break;
                case 10:
                    target = patrolLocations[9];
                    break;
            }
        }
        else if (target != null)
        {
            target = null;
        }

        if (rb.velocity.magnitude > 0.2f)
        {
            waitTimer = 0;
        }

        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        if (target != null)
        {
            moveDir = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
           // Debug.Log("Custom Patrol Targeted");
        }

        Vector3 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * patrolSpeed;// * Time.deltaTime;
        direction.z = transform.position.z;
        //rb.AddForce(force);


        moveDirDist = moveDir.magnitude;

        if (canPatrol)
        {
            if (moveDir.magnitude >= stopDistance)
            {
                //rb.velocity = force;
                rb.AddForce(force);
            }

            if (moveDir.magnitude <= 0.9f && rb.velocity.magnitude <= 0.3f)
            {
                if (waitTimer >= randomWaitTime)
                {
                    randomWaitTime = Random.Range(minWaitForThisLong, maxWaitForThisLong);
                    if (patrolInOrder)
                    {
                        if(randomSelectedLocation == patrolLocations.Length)
                        {
                            randomSelectedLocation = 1;
                        }
                        else
                        {
                            randomSelectedLocation++;
                        }
                        
                    }
                    else
                    {
                        randomSelectedLocation = Random.Range(1, patrolLocations.Length + 1);
                    }
                    
                }
                //Debug.Log("Is not supposed to move");
            }

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWayPointDistance)
            {
                currentWaypoint++;
            }
        }

    }
}
