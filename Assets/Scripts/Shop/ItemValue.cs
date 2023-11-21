using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemValue : Shop
{
    public int[] price;
    private int itemPrice;
    [SerializeField] private TextMeshProUGUI itemPriceTxt;

    private void OnEnable()
    {
        enumValue = PlayerPrefs.GetInt("EnumValue");
        CheckEnumStage();
        CheckValue();
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

    private void CheckValue()
    {
        switch (strItem)
        {
            case StrItem.Stage0:
                itemPrice = price[0];
                PlayerPrefs.SetFloat("ItemPrice", itemPrice);
                itemPriceTxt.SetText(itemPrice.ToString());
                break;
            case StrItem.Stage1:
                itemPrice = price[1];
                PlayerPrefs.SetFloat("ItemPrice", itemPrice);
                itemPriceTxt.SetText(itemPrice.ToString());
                break;
            case StrItem.Stage2:
                itemPrice = price[2];
                PlayerPrefs.SetFloat("ItemPrice", itemPrice);
                itemPriceTxt.SetText(itemPrice.ToString());
                break;
            case StrItem.Stage3:
                itemPrice = price[3];
                PlayerPrefs.SetFloat("ItemPrice", itemPrice);
                itemPriceTxt.SetText(itemPrice.ToString());
                break;
            case StrItem.Stage4:
                itemPrice = price[4];
                PlayerPrefs.SetFloat("ItemPrice", itemPrice);
                itemPriceTxt.SetText(itemPrice.ToString());
                break;
            case StrItem.Stage5:
                itemPrice = price[5];
                PlayerPrefs.SetFloat("ItemPrice", itemPrice);
                itemPriceTxt.SetText(itemPrice.ToString());
                break;
            case StrItem.Stage6:
                itemPrice = price[6];
                PlayerPrefs.SetFloat("ItemPrice", itemPrice);
                itemPriceTxt.SetText(itemPrice.ToString());
                break;
            case StrItem.Stage7:
                itemPrice = price[7];
                PlayerPrefs.SetFloat("ItemPrice", itemPrice);
                itemPriceTxt.SetText(itemPrice.ToString());
                break;
            case StrItem.Stage8:
                itemPrice = price[8];
                PlayerPrefs.SetFloat("ItemPrice", itemPrice);
                itemPriceTxt.SetText(itemPrice.ToString());
                break;
            case StrItem.Stage9:
                itemPrice = price[9];
                PlayerPrefs.SetFloat("ItemPrice", itemPrice);
                itemPriceTxt.SetText(itemPrice.ToString());
                break;
            case StrItem.Stage10:
                itemPriceTxt.SetText("SOLD OUT");
                break;
        }
    }

    public override void BuyItem()
    {
        if(strItem == StrItem.Stage10)
        {
            return;
        }
        else
        {
            strItem++;
            CheckValue();
        }
    }
}
