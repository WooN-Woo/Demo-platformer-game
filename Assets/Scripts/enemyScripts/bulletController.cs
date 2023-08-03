using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float bulletSpeed;

    [SerializeField]
    GameObject destroyEffect;

    playerHealtController playerHealtController;

    private void Awake()
    {
        playerHealtController = Object.FindAnyObjectByType<playerHealtController>();
    }

    private void Update()
    {
        transform.position += new Vector3(-bulletSpeed * transform.localScale.x * Time.deltaTime, 0f, 0f);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealtController.getDamage();
        }

        Instantiate(destroyEffect, gameObject.transform.position, gameObject.transform.rotation);

        Destroy(gameObject);

    }


}
