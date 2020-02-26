using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BEnemyAI : MonoBehaviour
{
    public float stopDistance = 0.35f;

    Transform player;
    Transform target;
    public float distToPlayer;
    public float speed = 4f;
    public float slowSpeed = 2f;
    public float noiseLevel;
    public float distToHearNoise = 8f;

    public float noiseCauseSuspicionLevel = 1.0f;
    public bool enemySeesPlayer;

    float nextWayPointDistance = 1f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;
    Vector2 moveDir;

    public float heardNoiseFollowDuration = 3f;
    float heardNoiseTimer = 10f;
    public bool runToPlayer;

    public bool canPatrol;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        
        if (enemySeesPlayer && canPatrol || canPatrol && noiseLevel > noiseCauseSuspicionLevel)
        {
            canPatrol = false;
            target = player;            
        }
        else if (!canPatrol && heardNoiseTimer > heardNoiseFollowDuration && !enemySeesPlayer)
        {
            canPatrol = true;
            target = null;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 distanceToThePlayer = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        distToPlayer = distanceToThePlayer.magnitude;
        if (distanceToThePlayer.magnitude < distToHearNoise)
        {
            noiseLevel = GameObject.FindObjectOfType<PlayerMovementScript>().suspicion;
        }

        heardNoiseTimer += Time.deltaTime;
        
        enemySeesPlayer = GameObject.FindObjectOfType<EnemyDetectionScript>().playerIsInSight;

        

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
        Vector2 forceSlow = direction * slowSpeed;// * Time.deltaTime;
        direction.z = transform.position.z;
        //rb.AddForce(force);
        if(target != null)
        {
            moveDir = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        }


        if (noiseLevel >= noiseCauseSuspicionLevel && !enemySeesPlayer)
        {
            heardNoiseTimer = 0;
        }
        if (!canPatrol)
        {
            if (moveDir.magnitude > stopDistance && enemySeesPlayer)
            {
                //rb.velocity = force;
                rb.AddForce(force);
                heardNoiseTimer = 0;
                Debug.Log("Is supposed to move");
            }
            else if (moveDir.magnitude <= stopDistance)
            {
                rb.velocity = new Vector2(0, 0);
                Debug.Log("Is not supposed to move");
            }

            if (heardNoiseTimer < heardNoiseFollowDuration && !enemySeesPlayer)
            {
                rb.AddForce(forceSlow);
            }
        }
        

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWayPointDistance)
        {
            currentWaypoint++;
        }
    }
}
