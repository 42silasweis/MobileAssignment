using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;
public class PlayerNavigationAI : MonoBehaviour
{
    public float rotationSpeed = 3f;
    public float stopDistance = 1.0f;
    public Vector3 target;
    public float speed = 200f;
    public float nextWayPointDistance = 3f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;
    bool currentlyHolding;

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
            seeker.StartPath(rb.position, target/*.position*/, OnPathComplete);
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
        //This function is to make the player sprite face the direction it is moving
        //I believe it requires the sprite to be a Child of the main Player/Object and rotated -90 degrees if the sprite is facing in the UP position
        //This is due to the Vector being a .forward which is necessary as that is the Z rotation axis that makes the sprite "rotate" and not flip like paper mario
        Vector3 moveDirection = GetComponent<Rigidbody2D>().velocity;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.fixedDeltaTime * rotationSpeed);
        }
        GetComponent<Animator>().SetFloat("velocity", GetComponent<Rigidbody2D>().velocity.magnitude);
    }

    void FixedUpdate()
    {
        target = GetComponent<PlayerMovementScript>().touchPosition;
        currentlyHolding = GetComponent<PlayerMovementScript>().currentlyHolding;

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
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed;// * Time.deltaTime;

        //rb.AddForce(force);
        Vector2 moveDir = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        if (moveDir.magnitude > stopDistance && currentlyHolding)
        {
            //rb.velocity = force;
            rb.AddForce(force);
        }
        else if (moveDir.magnitude < stopDistance)
        {
            rb.velocity = new Vector2(0, 0);
        }


        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWayPointDistance)
        {
            currentWaypoint++;
        }
    }
}
