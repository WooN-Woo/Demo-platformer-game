using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageController : MonoBehaviour
{
    playerHealtController playerHealtController;

    playerController playerController;

    private void Awake()
    {
        playerHealtController = Object.FindObjectOfType<playerHealtController>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealtController.getDamage();

            
        }
    }

}
