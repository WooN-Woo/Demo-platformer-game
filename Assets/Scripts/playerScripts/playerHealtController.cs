using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealtController : MonoBehaviour
{
    public int maxHealt;
    public int healt;

    [SerializeField]
    GameObject DeathEffect;

    UIController UIController;

    public float immortalityTime;
    float immortalityCounter;
    public SpriteRenderer spriteRenderer;

    playerController playerController;

    private void Awake()
    {
        playerController = Object.FindObjectOfType<playerController>();
        UIController =Object.FindObjectOfType<UIController>();
    }

    private void Start()
    {
        healt = maxHealt;
    }

    private void Update()
    {
        immortalityCounter-= Time.deltaTime;
        if(immortalityCounter <= 0)
        {
             spriteRenderer.color = new Color(spriteRenderer.color.r,
                spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        }
    }

    public void getDamage()
    {
        if(immortalityCounter <= 0)
        {
            healt--;

            if (healt <= 0)
            {
                Instantiate(DeathEffect, gameObject.transform.position, gameObject.transform.rotation);
                soundScript.instance.playSoundEffect(2);
                SceneManager.LoadScene(0);
                gameObject.SetActive(false);
            }
            else
            {
                immortalityCounter = immortalityTime;

                spriteRenderer.color = new Color(spriteRenderer.color.r,
                    spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);

                soundScript.instance.playSoundEffect(1);

                playerController.pushBackFnc();
            }
            UIController.UpdateHealt();
        }
    }
}
