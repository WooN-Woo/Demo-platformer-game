using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;

    [SerializeField]
    float jumpForce;

    bool isGround;
    bool isFall;
    bool jumpTwice;

    public Transform groundCheck;
    public LayerMask groundLayer;

    Rigidbody2D rb;

    Animator anim;

    public float pbPower, pbTime;
    float pbCounter;
    bool isRight;

    public float jump1force;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(pbCounter<= 0)
        {
            moveFnc();
            jumpFnc();
            anim1Fnc();
        }
        else
        {
            pbCounter -= Time.deltaTime;

            if(isRight == true)
            {
                rb.velocity = new Vector2(-pbPower, rb.velocity.y);
            }
            else
            {
                rb.velocity= new Vector2(pbPower,rb.velocity.y);
            }
        }

        animFnc();

    }

    void moveFnc()
    {
        float m = Input.GetAxis("Horizontal");
        float speed = m * movementSpeed;

        rb.velocity= new Vector2(speed, rb.velocity.y);
    }

    void jumpFnc()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.05f, groundLayer);

        if (isGround)
        {
            jumpTwice = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                soundScript.instance.playSoundEffect(3);
            }
            else
            {
                if(jumpTwice)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    soundScript.instance.playSoundEffect(3);
                    jumpTwice = false;
                }
                
            }
            
        }
    }

    void animFnc()
    {
        anim.SetFloat("movementSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGround", isGround);

        if (rb.velocity.y < -0.9f)
        {
            isFall = true;
        }
        else
        {
            isFall = false;
        }

        anim.SetBool("isFall", isFall);
    }

    void anim1Fnc()
    {
        Vector2 temporaryScale = transform.localScale;

        if (rb.velocity.x >0)
        {
            isRight = true;
            temporaryScale.x = 1f;
        }
        else if(rb.velocity.x < 0)
        {
            isRight = false;
            temporaryScale.x = -1f;
        }

        transform.localScale = temporaryScale;
    }

    public void pushBackFnc()
    {
        pbCounter = pbTime;
        rb.velocity = new Vector2 (0,rb.velocity.y);



        anim.SetTrigger("isHurt");
    }

    public void jump1Fnc()
    {
        soundScript.instance.playSoundEffect(3);
        rb.velocity = new Vector2 (rb.velocity.x, jump1force);
    }
}
