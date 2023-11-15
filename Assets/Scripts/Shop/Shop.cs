using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public enum StrItem { Stage0, Stage1, Stage2, Stage3, Stage4, Stage5, Stage6, Stage7, Stage8, Stage9, Stage10};
    public StrItem strItem;
    private GameManager gameManager;
    public int enumValue;
    [SerializeField] private GameObject strBuyBtn;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        enumValue = PlayerPrefs.GetInt("EnumValue");
        CheckEnumStage();
    }

    private void Update()
    {
        if (gameManager.coins < PlayerPrefs.GetFloat("ItemPrice"))
        {
            strBuyBtn.GetComponent<Button>().interactable = false;
        }
        else
        {
            strBuyBtn.GetComponent<Button>().interactable = true;
        }

        if (strItem == StrItem.Stage10)
        {
            strBuyBtn.GetComponent<Button>().interactable = false;
        }
    }

    private void CheckEnumStage()
    {
        switch (enumValue)
        {
            case 0:
                strItem = StrItem.Stage0;
                break;
            case 1:
                strItem = StrItem.Stage1;
                break;
            case 2:
                strItem = StrItem.Stage2;
                break;
            case 3:
                strItem = StrItem.Stage3;
                break;
            case 4:
                strItem = StrItem.Stage4;
                break;
            case 5:
                strItem = StrItem.Stage5;
                break;
            case 6:
                strItem = StrItem.Stage6;
                break;
            case 7:
                strItem = StrItem.Stage7;
                break;
            case 8:
                strItem = StrItem.Stage8;
                break;
            case 9:
                strItem = StrItem.Stage9;
                break;
            case 10:
                strItem = StrItem.Stage10;
                break;
        }
    }

    public void BuyItem()
    {
        if(gameManager.coins >= PlayerPrefs.GetFloat("ItemPrice"))
        {
            PlayerPrefs.SetFloat("Coins", gameManager.coins -= PlayerPrefs.GetFloat("ItemPrice"));
            gameManager.coinsTxt.text = Mathf.FloorToInt(PlayerPrefs.GetFloat("Coins")).ToString();
            strItem++;
            enumValue++;
            PlayerPrefs.SetInt("EnumValue", enumValue);
        }
    }
}
