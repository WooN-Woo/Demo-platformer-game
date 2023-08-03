using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cherryScript : MonoBehaviour
{
    playerHealtController playerHealtController;
    UIController UIController;

    [SerializeField]
    GameObject CollectEffect;

    private void Awake()
    {
        playerHealtController = Object.FindObjectOfType<playerHealtController>();
        UIController= Object.FindObjectOfType<UIController>();  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerHealtController.healt < playerHealtController.maxHealt)
        {
            playerHealtController.healt++;

            UIController.UpdateHealt();

            Instantiate(CollectEffect,gameObject.transform.position,gameObject.transform.rotation);

            soundScript.instance.playSoundEffect(4);

            gameObject.SetActive(false);

        }
        else
        {
            if (other.CompareTag("Player"))
            {
                Instantiate(CollectEffect, gameObject.transform.position, gameObject.transform.rotation);
                soundScript.instance.playSoundEffect(4);
                gameObject.SetActive(false);
            }
        }

    }

}    
