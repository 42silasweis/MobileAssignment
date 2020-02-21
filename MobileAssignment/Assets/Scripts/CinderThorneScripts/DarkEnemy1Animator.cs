using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkEnemy1Animator : MonoBehaviour
{
    bool movingRight;
    bool movingLeft;
    bool movingUp;
    bool movingDown;
    Animator anim;
    //public bool canMove;

    bool inMidWarp;
    bool talking;
    Vector2 stopSpeed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        //GetComponent<Animator>().SetFloat("x", velocity.x);
        //GetComponent<Animator>().SetFloat("y", velocity.y);
        float x = velocity.x;
        float y = velocity.y;
        if (x > 0)
        {
            movingRight = true;
            movingLeft = false;
            movingUp = false;
            movingDown = false;
        }
       if (x < 0)
        {
            movingLeft = true;
            movingRight = false;
            movingUp = false;
            movingDown = false;
        }
        if (y > 0)
        {
            movingUp = true;
            movingDown = false;
            movingRight = false;
            movingLeft = false;
        }
        if (y < 0)
        {
            movingDown = true;
            movingUp = false;
            movingRight = false;
            movingLeft = false;
        }
        GetComponent<Animator>().SetFloat("x", x);
        GetComponent<Animator>().SetFloat("y", y);
        GetComponent<Animator>().SetBool("Right", movingRight);
        GetComponent<Animator>().SetBool("Up", movingUp);

        if (x == 0 && y == 0)
        {
            GetComponent<Animator>().speed = 0;
        }
        else
        {
            GetComponent<Animator>().speed = 1;
        }


        
        
        if(x == 0 && y == 0 && movingRight)
        {
            GetComponent<Animator>().speed = 0;
            anim.Play("PlayerWalkRight", 0, 0);
        }

        if (x == 0 && y == 0 && movingLeft)
        {
            GetComponent<Animator>().speed = 0;
            anim.Play("PlayerWalkLeft", 0, 0);
        }

        if (x == 0 && y == 0 && movingUp)
        {
            GetComponent<Animator>().speed = 0;
            anim.Play("PlayerWalkUp", 0, 0);
        }

        if (x == 0 && y == 0 && movingDown)
        {
            GetComponent<Animator>().speed = 0;
            anim.Play("PlayerWalkDown", 0, 0);
        }


        //GetComponent<Animator>().Play("YOUR_ANIMATION_NAME_HERE", 0, 0);
    }
}
