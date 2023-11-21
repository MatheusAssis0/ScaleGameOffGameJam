using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemStrength : Shop
{
    public int[] strToAdd;
    private int str;
    private MoveBall script;
    [SerializeField] private GameObject itemBar;

    private void Start()
    {
        script = FindObjectOfType<MoveBall>();
    }

    private void OnEnable()
    {
        enumValue = PlayerPrefs.GetInt("EnumValue");
        CheckEnumStage();
        CheckItemStage();
    }

    private void CheckEnumStage()
    {
        switch(enumValue)
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

    private void CheckItemStage()
    {
        switch (strItem)
        {
            case StrItem.Stage0:
                str = strToAdd[0];
                itemBar.GetComponent<Image>().fillAmount = 0f;
                break;
            case StrItem.Stage1:
                str = strToAdd[1];
                itemBar.GetComponent<Image>().fillAmount = 0.1f;
                break;
            case StrItem.Stage2:
                str = strToAdd[2];
                itemBar.GetComponent<Image>().fillAmount = 0.2f;
                break;
            case StrItem.Stage3:
                str = strToAdd[3];
                itemBar.GetComponent<Image>().fillAmount = 0.3f;
                break;
            case StrItem.Stage4:
                str = strToAdd[4];
                itemBar.GetComponent<Image>().fillAmount = 0.4f;
                break;
            case StrItem.Stage5:
                str = strToAdd[5];
                itemBar.GetComponent<Image>().fillAmount = 0.5f;
                break;
            case StrItem.Stage6:
                str = strToAdd[6];
                itemBar.GetComponent<Image>().fillAmount = 0.6f;
                break;
            case StrItem.Stage7:
                str = strToAdd[7];
                itemBar.GetComponent<Image>().fillAmount = 0.7f;
                break;
            case StrItem.Stage8:
                str = strToAdd[8];
                itemBar.GetComponent<Image>().fillAmount = 0.8f;
                break;
            case StrItem.Stage9:
                str = strToAdd[9];
                itemBar.GetComponent<Image>().fillAmount = 0.9f;
                break;
            case StrItem.Stage10:
                itemBar.GetComponent<Image>().fillAmount = 1f;
                break;
        }
    }

    public override void BuyItem()
    {
        if (strItem == StrItem.Stage10)
        {
            return;
        }
        else
        {
            PlayerPrefs.SetFloat("Strength", script.strength += str);
            strItem++;
            CheckItemStage();
        }
    }
}
