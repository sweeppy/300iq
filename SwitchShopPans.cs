using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchShopPans : MonoBehaviour
{
    public MainMenu scriptMainMenu;
    public GameObject ShopPan_2;
    public GameObject ShopPan_3;
    public GameObject closeShopButton;
    public GameObject shopPan;
    public GameObject shopPan_3;

    public void SwithPan_2()
    {
        scriptMainMenu.shopPan = shopPan;
        ShopPan_2.SetActive(true);
        shopPan.SetActive(false);
        shopPan_3.SetActive(false);

       

}
    public void CloseShopPan_2()
    {
        ShopPan_2.SetActive(false);
    }

    public void SwitchShopPan_3()
    {
        scriptMainMenu.shopPan = shopPan;
        ShopPan_2.SetActive(false);
        shopPan.SetActive(false);
        shopPan_3.SetActive(true);
        scriptMainMenu.perClick2.text = scriptMainMenu.clickEnergy.ToString();
        scriptMainMenu.perSec2.text = scriptMainMenu.allEnergyPerSec.ToString();
    }
    public void CloseShopPan_3()
    {
        ShopPan_3.SetActive(false);
    }



}

