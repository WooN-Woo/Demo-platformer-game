using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tankController : MonoBehaviour
{
    public enum tankStates {shootState, hitState,moveState};

    public tankStates currentState;


    [SerializeField]
    Transform tankObject;


    public Animator anim;


    public float movementSpeed;
    public Transform leftTarget, rightTarget;
    bool isRight;


    public GameObject bullet;
    public Transform bulletTarget;
    public float bulletTime;
    float bulletCounter;



    public float hitTime;
    float hitCounter;
    public GameObject tankHitCheck;


    public int healt;
    [SerializeField] GameObject bumEffect;
    bool islive;


    private void Start()
    {
        currentState= tankStates.shootState;
    }

    private void Update()
    {
        switch(currentState)
        {
            case tankStates.shootState:

                bulletCounter -= Time.deltaTime;

                

                if (bulletCounter <= 0 )
                {
                    bulletCounter = bulletTime;
                    var newbullet = Instantiate(bullet, bulletTarget.transform.position, bulletTarget.transform.rotation);
                    newbullet.transform.localScale = tankObject.transform.localScale;
                }


                break;
            case tankStates.hitState:

               

                if (hitCounter>0)
                {
                    hitCounter-=Time.deltaTime;
                    if(hitCounter<=0)
                    {
                        currentState= tankStates.moveState;
                    }
                }

                break;
            case tankStates.moveState:

                if (isRight)
                {
                    tankObject.position += new Vector3(movementSpeed * Time.deltaTime, 0f, 0f);

                    

                    if (tankObject.position.x > rightTarget.position.x)
                    {
                        tankObject.localScale= new Vector3(1,tankObject.localScale.y,tankObject.localScale.z);
                        isRight = false;

                        stopMovementFnc();
                    }
                }
                else
                {
                    tankObject.position += new Vector3(-movementSpeed * Time.deltaTime, 0f, 0f);

                    

                    if (tankObject.position.x < leftTarget.position.x)
                    {
                        tankObject.localScale = new Vector3(-1, tankObject.localScale.y, tankObject.localScale.z);
                        isRight = true;

                        stopMovementFnc();
                    }
                }

                break;

        }
    }

    public void getHitFnc()
    {
        
        currentState= tankStates.hitState;
        hitCounter = hitTime;
        anim.SetTrigger("Hit");

        healt--;

        if(healt<=0)
        {
            soundScript.instance.playSoundEffect(2);
            tankObject.parent.gameObject.SetActive(false);
            Instantiate(bumEffect,tankObject.transform.position,tankObject.transform.rotation);
            SceneManager.LoadScene(0);
        }
    }


    public void stopMovementFnc()
    {
        tankHitCheck.SetActive(true);
        currentState = tankStates.shootState;
        bulletCounter = bulletTime;
        anim.SetTrigger("StopMovement");
    }


}