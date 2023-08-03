using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemScript : MonoBehaviour
{
    levelManager levelManager;
    UIController UIController;

    [SerializeField]
    GameObject CollectEffect;

    private void Awake()
    {
        levelManager= Object.FindObjectOfType<levelManager>();
        UIController= Object.FindObjectOfType<UIController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelManager.totalGemCount++;
            Instantiate(CollectEffect, gameObject.transform.position, gameObject.transform.rotation);
            soundScript.instance.playRandomSoundEffect(7);
            UIController.gemCounter();
            gameObject.SetActive(false);
        }
    }
}
