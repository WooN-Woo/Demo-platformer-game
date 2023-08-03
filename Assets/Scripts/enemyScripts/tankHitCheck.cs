using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankHitCheck : MonoBehaviour
{
    playerController playerController;
    tankController tankController;
    [SerializeField]
    GameObject cherry, DeathEffect;
    

    private void Awake()
    {
        playerController = Object.FindAnyObjectByType<playerController>();
        tankController = Object.FindAnyObjectByType<tankController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.jump1Fnc();

            Instantiate(DeathEffect, tankController.transform.position, tankController.transform.rotation);
            Instantiate(cherry, tankController.transform.position, tankController.transform.rotation);

            tankController.getHitFnc();

            gameObject.SetActive(false);
        }
    }
}
