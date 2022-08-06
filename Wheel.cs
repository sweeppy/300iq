using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Wheel : MonoBehaviour
{
    public WheelShop scriptWheelShop;


    public string nameWheel;
    public long priceWheel;
    public Text TextWheel;
    public bool isBuy;
    public GameObject BuyButton;

    


    
    public void BuyWheel()
    {
        if (isBuy == false)
        {
            scriptWheelShop.nameWheel = nameWheel;
            scriptWheelShop.priceWheel = priceWheel;
            scriptWheelShop.buyButton = BuyButton;
            scriptWheelShop.TextWheel = TextWheel;
            scriptWheelShop.BuyWheels();
        }
        else
        {
            scriptWheelShop.nameWheel = nameWheel;
            scriptWheelShop.priceWheel = priceWheel;
            scriptWheelShop.buyButton = BuyButton;
            scriptWheelShop.TextWheel = TextWheel;

            scriptWheelShop.BoughtWheels();
        }
    }

}
