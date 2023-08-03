using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    Image heart1_Img, heart2_Img, heart3_Img;

    [SerializeField]
    Sprite emptyHeart, filledHeart, halfFilledHeart;

    playerHealtController playerHealtController;

    [SerializeField]
    TMP_Text gemText;

    levelManager levelManager;

    private void Awake()
    {
        playerHealtController = Object.FindObjectOfType<playerHealtController>();
        levelManager= Object.FindObjectOfType<levelManager>();
    }


    public void UpdateHealt()
    {
        switch(playerHealtController.healt)
        {
            case 6:
                heart1_Img.sprite = filledHeart;
                heart2_Img.sprite = filledHeart;
                heart3_Img.sprite = filledHeart;
                break;

            case 5:
                heart1_Img.sprite = filledHeart;
                heart2_Img.sprite = filledHeart;
                heart3_Img.sprite = halfFilledHeart;
                break;
            case 4:
                heart1_Img.sprite = filledHeart;
                heart2_Img.sprite = filledHeart;
                heart3_Img.sprite = emptyHeart;
                break;
            case 3:
                heart1_Img.sprite = filledHeart;
                heart2_Img.sprite = halfFilledHeart;
                heart3_Img.sprite = emptyHeart;
                break;
            case 2:
                heart1_Img.sprite = filledHeart;
                heart2_Img.sprite = emptyHeart;
                heart3_Img.sprite = emptyHeart;
                break;  
            case 1:
                heart1_Img.sprite = halfFilledHeart;
                heart2_Img.sprite = emptyHeart;
                heart3_Img.sprite = emptyHeart;
                break; 
            case 0:
                heart1_Img.sprite = emptyHeart;
                heart2_Img.sprite = emptyHeart;
                heart3_Img.sprite = emptyHeart;
                break; 

        }
    }

    public void gemCounter()
    {
       gemText.text = levelManager.totalGemCount.ToString();
    }
}
