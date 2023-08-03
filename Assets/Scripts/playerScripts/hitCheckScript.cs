using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitCheckScript : MonoBehaviour
{
    [SerializeField]
    GameObject DeathEffect;

    frogController frogController;
  
    playerController playerController;

    [SerializeField]
    GameObject cherry;

    private void Awake()
    {
        frogController= Object.FindAnyObjectByType<frogController>();
        playerController= Object.FindAnyObjectByType<playerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Frog"))
        {
            other.transform.parent.gameObject.SetActive(false);

            Instantiate(DeathEffect, frogController.transform.position, frogController.transform.rotation);

            soundScript.instance.playSoundEffect(0);

            Instantiate(cherry, frogController.transform.position, frogController.transform.rotation);

            playerController.jump1Fnc();
        }

    }
}
