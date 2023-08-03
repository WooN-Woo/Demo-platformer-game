using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogController : MonoBehaviour
{
    
    public float moveSpeed;
    public Transform leftTarget, rightTarget;

    bool isRight;

    public float moveTime, pauseTime;
    float moveCounter, pauseCounter;

    Rigidbody2D rb;
    Animator anim;

    public SpriteRenderer sr;

   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        leftTarget.parent = null; 
        rightTarget.parent = null;

        isRight = true;

        moveCounter = moveTime;

    }

    private void Update()
    {

        if (moveCounter > 0)
        {

            moveCounter -= Time.deltaTime;

            if (isRight)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

                sr.flipX = true;

                if (transform.position.x > rightTarget.position.x)
                {
                    isRight = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);

                sr.flipX = false;

                if (transform.position.x < leftTarget.position.x)
                {
                    isRight = true;
                }
            }

            if (moveCounter <= 0)
            {
                pauseCounter = pauseTime;
            }

            anim.SetBool("isMove", true);
        }
        else if (pauseCounter > 0)
        {
            pauseCounter -= Time.deltaTime;
            rb.velocity = new Vector2(0,rb.velocity.y);

            if(pauseCounter<=0)
            {
                moveCounter = moveTime;
            }

            anim.SetBool("isMove", false);

        }
    }
}


