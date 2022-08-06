using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
[Serializable]
public class Item : MonoBehaviour
{
    public MainMenu scriptMainMenu;

    public double priceItem;
    public int bonusClick;
    public Text PriceText;
    public string nameItem;
    public int energyPerSec;
    public string nameItem_2;
    public double priceItem_2;
    public Text PriceText_2;
    public GameObject buyButton;
    public double firstPrice;
    public GameObject buyButton_2;
    public double firstPrice_2;


    public void BuyItem()
    {
        scriptMainMenu.priceItem = priceItem;
        scriptMainMenu.bonusClick = bonusClick;
        scriptMainMenu.PriceText = PriceText;
        scriptMainMenu.nameItem = nameItem;
        scriptMainMenu.BuyItem();
        scriptMainMenu.buyButton = buyButton;
        scriptMainMenu.firstPrice = firstPrice;





    }
    public void BuyItem_2()
    {
        scriptMainMenu.energyPerSec = energyPerSec; /*shopPan2*/
        scriptMainMenu.nameItem_2 = nameItem_2;
        scriptMainMenu.priceItem_2 = priceItem_2;
        scriptMainMenu.PriceText = PriceText;
        scriptMainMenu.PriceText_2 = PriceText_2;
        scriptMainMenu.BuyItem_2();
        scriptMainMenu.buyButton_2 = buyButton_2;
        scriptMainMenu.firstPrice_2 = firstPrice_2;





    }
}