using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WheelShop : MonoBehaviour
{
    public MainMenu scriptMainMenu;
    public OpenHamsters scriptopenHamsters;

    public string nameWheel;
    public long priceWheel;
    public GameObject[] allWheels;

    public WheelSkin[] info;
    private bool[] StockCheck;

    public Text TextWheel;
    public Transform wheels;
    public int index;
    public int indexInMainMenu;
    public GameObject buyButton;
    [SerializeField] public int money;
    public List<string> WheelList = new List<string>();
    public GameObject[] WheelInMainMenu;
    public GameObject ANWheel;
    

    



    public void Start()
    {
        for (int i = 0; i < info.Length; i++)
        {
            if (info[i].isChosen)
            {
                ANWheel = WheelInMainMenu[i];
            }
        }

        //allWheels[0].GetComponent<Wheel>().BuyButton.GetComponent<Button>().interactable = false;
        //ANWheel = WheelInMainMenu[0];
    }

    //public void Awake()
    //{
    //    for (int y = 0; y < info.Length; y++)
    //    {
    //        if (info[y].isChosen == true)
    //        {
    //            allWheels[y].GetComponent<Wheel>().TextWheel.text = "выбрано";
    //            BoughtWheels();

    //        }
    //    }
        



        

    //}


    public void Check()
    {
        if (WheelList.Count > 1)
        {
            for (int y = 0; y < allWheels.Length; y++)
            {

                allWheels[y].GetComponent<Wheel>().BuyButton.GetComponent<Button>().interactable = true;
                if (allWheels[y].GetComponent<Wheel>().TextWheel.text == "выбрано")
                {
                    allWheels[y].GetComponent<Wheel>().TextWheel.text = "выбрать";
                }

                if (allWheels[y].GetComponent<Wheel>().nameWheel == WheelList[WheelList.Count - 1])
                {
                    allWheels[y].GetComponent<Wheel>().TextWheel.text = "выбрано";
                    allWheels[y].GetComponent<Wheel>().priceWheel = 0;
                    info[index].inStock = true;
                    for (int i = 0; i < info.Length; i++)
                    {
                        info[i].isChosen = false;
                    }
                    info[index].isChosen = true;
                    indexInMainMenu = index;
                    allWheels[y].GetComponent<Wheel>().BuyButton.GetComponent<Button>().interactable = false;
                    allWheels[y].GetComponent<Wheel>().isBuy = true;
                }
                if (WheelInMainMenu[indexInMainMenu] == info[index].isChosen)
                    ANWheel = WheelInMainMenu[indexInMainMenu];




            }
            //WheelList.Clear();

        }
    }
        
            
            

    public void BuyWheels()
    {
        
        if (scriptMainMenu.money >= priceWheel)
        {
            scriptMainMenu.money -= priceWheel;
            WheelList.Add(nameWheel);
            Check();
        }
    }
    public void BoughtWheels()
    {
        WheelList.Add(nameWheel);
        for (int j = 0; j < allWheels.Length; j++)
        {
            if (info[j].inStock == true)
            {
                allWheels[j].GetComponent<Wheel>().TextWheel.text = "выбрать";
            }
            else allWheels[j].GetComponent<Wheel>().TextWheel.text = priceWheel.ToString() + "$";


            for (int y = 0; y < allWheels.Length; y++)
            {
                if (info[y].inStock == false)
                {
                    if (allWheels[y].GetComponent<Wheel>().priceWheel >= 1000)
                        allWheels[y].GetComponent<Wheel>().TextWheel.text = (allWheels[y].GetComponent<Wheel>().priceWheel / 1000).ToString() + "тыс.$";
                    if (allWheels[y].GetComponent<Wheel>().priceWheel >= 1000000)
                        allWheels[y].GetComponent<Wheel>().TextWheel.text = (allWheels[y].GetComponent<Wheel>().priceWheel / 1000000).ToString() + "млн.$";
                    if (allWheels[y].GetComponent<Wheel>().priceWheel >= 1000000000)
                        allWheels[y].GetComponent<Wheel>().TextWheel.text = (allWheels[y].GetComponent<Wheel>().priceWheel / 1000000000).ToString() + "млрд.$";
                }
            }

            allWheels[j].GetComponent<Wheel>().BuyButton.GetComponent<Button>().interactable = true;

            if (allWheels[j].GetComponent<Wheel>().nameWheel == WheelList[WheelList.Count - 1])
            {
                allWheels[j].GetComponent<Wheel>().TextWheel.text = "выбрано";
                for (int i = 0; i < info.Length; i++)
                {
                    info[i].isChosen = false;
                }
                info[index].isChosen = true;
                indexInMainMenu = index;
                
                allWheels[j].GetComponent<Wheel>().BuyButton.GetComponent<Button>().interactable = false;
            }
            if (WheelInMainMenu[indexInMainMenu] == info[index].isChosen)
                ANWheel = WheelInMainMenu[indexInMainMenu];
        }
        
        //WheelList.Clear();
    }

    public void ScrollRight()
    {
        if (index < wheels.childCount - 1)
        {
            index++;
            indexInMainMenu = index;



            for (int i = 0; i < wheels.childCount; i++)
            {
                wheels.GetChild(i).gameObject.SetActive(false);
                wheels.GetChild(index).gameObject.SetActive(true); 
            }
         
            
        }
    }

    public void ScrollLeft()
    {
        if (index > 0)
        {
            index--;
            indexInMainMenu = index;

            for (int i = 0; i < wheels.childCount; i++)
                wheels.GetChild(i).gameObject.SetActive(false);
            wheels.GetChild(index).gameObject.SetActive(true);
        }
    }



}


[System.Serializable]
public class WheelSkin
{

    public bool inStock;
    public bool isChosen;

}