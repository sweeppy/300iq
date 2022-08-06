using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemakeThings : MonoBehaviour
{
    public MainMenu scriptMainMenu;
 
    public GameObject electric_1stStage;
    public GameObject electric_2ndStage;
    public GameObject shadow_1;
    public GameObject shadow_2;
    public GameObject BoostAir;
    public GameObject Smoke;
    public GameObject shadow_4;
    public GameObject window;
    public GameObject Picture;
    public GameObject ELprotector;
    public GameObject Wordrobe;
    public GameObject o2;

    public void SwitchObject_Electric()
    {
            scriptMainMenu.electric_1stStage = electric_1stStage;
            scriptMainMenu.electric_2ndStage = electric_2ndStage;
            electric_1stStage.SetActive(false);
            electric_2ndStage.SetActive(true);
            shadow_1.SetActive(false);
            shadow_2.SetActive(true);
    }
    public void SwitchObject_AirBoost()
    {
        if (scriptMainMenu.shopPan == false)
        {
                scriptMainMenu.BoostAir = BoostAir;
                scriptMainMenu.Smoke = Smoke;
                BoostAir.SetActive(true);
                Smoke.SetActive(true);
                scriptMainMenu.shadow_4 = shadow_4;
                shadow_4.SetActive(true);

        }
    }
    
    public void SwitchObject_Window()
    {
        Picture.SetActive(false);
        window.SetActive(true);
    }

    public void SwitchObjectELProtector()
    {
        ELprotector.SetActive(true);
    }
    public void SwitchObjectO2()
    {
        Wordrobe.SetActive(false);
        o2.SetActive(true);
    }




}
