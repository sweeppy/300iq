using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class MainMenu : MonoBehaviour
{
    public OpenHamsters scriptOpenHamsters;

    public SwitchShopPans scriptSwitchShopPans;

    public WheelShop scriptWheelShop;

    public RemakeThings scriptRemakeThings;

    [SerializeField] public long energy;

    public Text energyText;
    public Text moneyText;

    public GameObject shopPan;
    public GameObject WheelOnMain;
    public GameObject StaticPanel;
    public GameObject closeShopButton;


    [SerializeField] public long money;


    public double allEnergyPerSec = 0;
    public double clickEnergy = 1;
    public Text perClick;
    public Text perSec;
    public Text perClick2;
    public Text perSec2;

    public double finalItemPrice;
    public long finalEnergy;



    public GameObject TradePan;
    public GameObject closeTradeButton;
    



    public double exchangeRate;
    public Text MoneyRate;

    public GameObject exchangeButton;
    public GameObject shopButton;


    public GameObject[] allItems;
    public string nameItem;
    public double priceItem;
    public int bonusClick;
    public Text PriceText;
    public double firstPrice;
    public GameObject buyButton;

    public GameObject[] allItems_2;
    public int energyPerSec;
    public string nameItem_2;
    public double priceItem_2;
    public Text PriceText_2;
    public GameObject buyButton_2;
    public double firstPrice_2;



    public List<string> list_1 = new List<string>();
    public List<string> list_2 = new List<string>();

    [SerializeField]public int exchangeSeconds = 300;
    public Text ExchangeSecondsText;
    public Text ForMethod;


    public GameObject electric_1stStage;
    public GameObject electric_2ndStage;
    public GameObject BoostAir;
    public GameObject Smoke;
    public GameObject shadow_4;


    
    public GameObject WheelPan;
    public GameObject wheelButton;

    private SaveMainMenu sv = new SaveMainMenu();




    private void Start()
    {
        scriptWheelShop.ANWheel = scriptWheelShop.WheelInMainMenu[0];
        energyText.text = finalEnergy.ToString();
        WheelOnMain = scriptWheelShop.WheelInMainMenu[0];


        StartCoroutine(ClickPerSec());
        StartCoroutine(Timer());
        for (int y = 1; y < allItems.Length; y++)
        {
            allItems[y].GetComponent<Item>().buyButton.GetComponent<Button>().interactable = false;
        }
        for (int i = 1; i < allItems_2.Length; i++)
        {
            allItems_2[i].GetComponent<Item>().buyButton_2.GetComponent<Button>().interactable = false;
        }


        CheckCost();
        CheckCost_2();
        scriptWheelShop.BoughtWheels();
        WheelOnMain = scriptWheelShop.ANWheel;


        for (int i = 0; i < scriptWheelShop.info.Length; i++)
        {
            if (scriptWheelShop.info[i].isChosen)
            {
                scriptWheelShop.allWheels[i].GetComponent<Wheel>().TextWheel.text = "выбрано";
                scriptWheelShop.allWheels[i].GetComponent<Wheel>().BuyButton.GetComponent<Button>().interactable = false; /*делает кнопку выбранного колеса неактивной с началла игры*/
                scriptWheelShop.ANWheel = scriptWheelShop.WheelInMainMenu[i];
                for (int j = 0; j < scriptWheelShop.WheelInMainMenu.Length; j++)
                {
                    scriptWheelShop.WheelInMainMenu[j].SetActive(false);
                }
                scriptWheelShop.WheelInMainMenu[i].SetActive(true);
            }
        }

        for (int i = 0; i < scriptOpenHamsters.Hamsters.Length; i++)
        {
            if (scriptOpenHamsters.Hamsters[i].GetComponent<HamstersScript>().isChosen == true)
            {
                scriptOpenHamsters.NowHamster = scriptOpenHamsters.Hamsters[i].GetComponent<HamstersScript>().Hamster2;
            }
            
        }
        for (int i = 0; i < scriptOpenHamsters.Hamsters.Length; i++)
        {
            scriptOpenHamsters.Hamsters[i].GetComponent<HamstersScript>().Hamster1.SetActive(false); /*выключает всех хомяков в начале игры*/
            scriptOpenHamsters.Hamsters[i].GetComponent<HamstersScript>().Hamster2.SetActive(false);

        }
        scriptOpenHamsters.NowHamster.SetActive(true); /*делает нужного хомяка setActive(true)*/

        for (int y = 0; y < scriptOpenHamsters.Hamsters.Length; y++)
        {
            if (scriptOpenHamsters.Hamsters[y].GetComponent<HamstersScript>().inStock == true)
            {
                scriptOpenHamsters.Hamsters[y].GetComponent<HamstersScript>().OpenButton.SetActive(false);
                scriptOpenHamsters.Hamsters[y].GetComponent<HamstersScript>().OpenedButton.SetActive(true);
                scriptOpenHamsters.Hamsters[y].GetComponent<HamstersScript>().OpenedButton.GetComponent<Button>().interactable = false;
                scriptOpenHamsters.Hamsters[y].GetComponent<HamstersScript>().imageHamster.SetActive(false);
                scriptOpenHamsters.Hamsters[y].GetComponent<HamstersScript>().imageHamster2.SetActive(true);
            }
        }










    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SVMainMenu"))
        {
            sv = JsonUtility.FromJson<SaveMainMenu>(PlayerPrefs.GetString("SVMainMenu"));
            list_1 = sv.list_1;
            list_2 = sv.list_2;
            energy = sv.energy;
            money = sv.money;
            allEnergyPerSec = sv.allEnergyPerSec;                                       /*script MainMenu*/
            clickEnergy = sv.clickEnergy;
            finalItemPrice = sv.finalItemPrice;
            finalEnergy = sv.finalEnergy;
            exchangeRate = sv.exchangeRate;
            energyPerSec = sv.energyPerSec;
            exchangeSeconds = sv.exchangeSeconds;
            for (int i = 0; i < allItems.Length; i++)
            {
                allItems[i].GetComponent<Item>().priceItem = sv.priceItem[i];
                
            }
            CheckCost();
            for (int i = 0; i < allItems_2.Length; i++)
            {
                allItems_2[i].GetComponent<Item>().priceItem_2 = sv.priceItem_2[i];
            }
            CheckCost_2();



            scriptWheelShop.WheelList = sv.WheelList;
            for (int i = 0; i < scriptWheelShop.info.Length; i++)
            {
                scriptWheelShop.info[i] = sv.info[i];
            }
            for (int i = 0; i < scriptWheelShop.info.Length; i++)
            {
                scriptWheelShop.allWheels[i].GetComponent<Wheel>().priceWheel = (long)sv.priceWheel[i];                           /*wheelprice*/
            }

            scriptWheelShop.BoughtWheels();



            for (int i = 0; i < scriptOpenHamsters.Hamsters.Length; i++)
            {
                scriptOpenHamsters.Hamsters[i].GetComponent<HamstersScript>().isChosen = sv.HamstersIsChosen[i];
                scriptOpenHamsters.Hamsters[i].GetComponent<HamstersScript>().inStock = sv.HamstersInStock[i];

            }
            scriptOpenHamsters.subtractSec = sv.subtractSec;

            if (allItems[5].GetComponent<Item>().priceItem > 1200000)
            {
                BoostAir.SetActive(true);

                shadow_4.SetActive(true);
            }
            if (allItems[9].GetComponent<Item>().priceItem > 1000000000)
            {
                scriptRemakeThings.SwitchObjectO2();
            }


            if (allItems_2[3].GetComponent<Item>().priceItem_2 > 1400000)
            {
                scriptRemakeThings.SwitchObject_Electric();
            }
            if (allItems_2[6].GetComponent<Item>().priceItem_2 > 150000000)
            {
                scriptRemakeThings.SwitchObject_Window();
            }
            if (allItems_2[7].GetComponent<Item>().priceItem_2 > 750000000)
            {
                scriptRemakeThings.SwitchObjectELProtector();
            }





        }
        else
        {
            exchangeRate = 1;
        }
    }

    void CheckCost()
    {


        for (int y = 0; y < allItems.Length; y++)
        {
            if (list_1.Count > 1)
            {
                if (allItems[y].GetComponent<Item>().nameItem == list_1[list_1.Count - 1])
                {


                    allItems[y].GetComponent<Item>().PriceText.text = allItems[y].GetComponent<Item>().priceItem.ToString() + "$";



                    if (allItems[y].GetComponent<Item>().priceItem >= 1000)
                    {
                        allItems[y].GetComponent<Item>().PriceText.text = Math.Round((double)allItems[y].GetComponent<Item>().priceItem / 1000, 2).ToString() + "тыс." + "$";
                    }
                    if (allItems[y].GetComponent<Item>().priceItem >= 1000000)
                    {
                        allItems[y].GetComponent<Item>().PriceText.text = Math.Round((double)allItems[y].GetComponent<Item>().priceItem / 1000000, 2).ToString() + "млн." + "$";
                    }
                    if (allItems[y].GetComponent<Item>().priceItem >= 1000000000)
                    {
                        allItems[y].GetComponent<Item>().PriceText.text = Math.Round((double)allItems[y].GetComponent<Item>().priceItem / 1000000000, 2).ToString() + "млрд." + "$";
                    }
                }

                if (allItems[y].GetComponent<Item>().priceItem > allItems[y].GetComponent<Item>().firstPrice * 3.375)
                {
                    if (y != allItems.Length - 1) allItems[y + 1].GetComponent<Item>().buyButton.GetComponent<Button>().interactable = true;

                    allItems[y].GetComponent<Item>().PriceText.text = "куплено";
                    allItems[y].GetComponent<Item>().buyButton.GetComponent<Button>().interactable = false;
                    //if (allItems[y].GetComponent<Item>().PriceText.text == "куплено")
                    //{
                    //    allItems[y + 1].GetComponent<Item>().buyButton.GetComponent<Button>().interactable = true;
                    //}
                }
            }
        }


    }
    public void BuyItem()
    {
        if (money >= priceItem)
        {
            money -= (long)priceItem;
            clickEnergy += bonusClick * scriptOpenHamsters.bonusEnergy;
            list_1.Add(nameItem);

            for (int y = 0; y < allItems.Length; y++)
            {
                if (allItems[y].GetComponent<Item>().nameItem == list_1[list_1.Count - 1])
                    allItems[y].GetComponent<Item>().priceItem = priceItem * 1.5;
            }
            CheckCost();
        }
        else
        {

        }
    }





    void CheckCost_2()
    {


        for (int i = 0; i < allItems_2.Length; i++)
        {
            if (list_2.Count > 1)
            {
                if (allItems_2[i].GetComponent<Item>().nameItem_2 == list_2[list_2.Count - 1])
                {


                    allItems_2[i].GetComponent<Item>().PriceText_2.text = allItems_2[i].GetComponent<Item>().priceItem_2.ToString() + "$";

                    if (allItems_2[i].GetComponent<Item>().priceItem_2 > 1000)
                    {
                        allItems_2[i].GetComponent<Item>().PriceText_2.text = Math.Round(allItems_2[i].GetComponent<Item>().priceItem_2 / 1000, 2).ToString() + "тыс." + "$";
                    }
                    if (allItems_2[i].GetComponent<Item>().priceItem_2 > 1000000)
                    {
                        allItems_2[i].GetComponent<Item>().PriceText_2.text = Math.Round(allItems_2[i].GetComponent<Item>().priceItem_2 / 1000000, 2).ToString() + "млн." + "$";
                    }
                    if (allItems_2[i].GetComponent<Item>().priceItem_2 > 1000000000)
                    {
                        allItems_2[i].GetComponent<Item>().PriceText_2.text = Math.Round(allItems_2[i].GetComponent<Item>().priceItem_2 / 1000000000, 2).ToString() + "млрд." + "$";
                    }
                }
                if (allItems_2[i].GetComponent<Item>().priceItem_2 > allItems_2[i].GetComponent<Item>().firstPrice_2 * 3.375)
                {
                    if (i != allItems_2.Length - 1) allItems_2[i + 1].GetComponent<Item>().buyButton_2.GetComponent<Button>().interactable = true;
                    allItems_2[i].GetComponent<Item>().PriceText_2.text = "куплено";
                    allItems_2[i].GetComponent<Item>().buyButton_2.GetComponent<Button>().interactable = false;

                }

            }

        }
    }

    public void BuyItem_2()
    {
        if (money >= priceItem_2)
        {
            money -= (long)priceItem_2;
            allEnergyPerSec += energyPerSec * scriptOpenHamsters.bonusEnergy;
            list_2.Add(nameItem_2);

            for (int i = 0; i < allItems_2.Length; i++)
            {
                if (allItems_2[i].GetComponent<Item>().nameItem_2 == list_2[list_2.Count - 1])
                    allItems_2[i].GetComponent<Item>().priceItem_2 *= 1.5;
            }

            CheckCost_2();
        }
        else
        {

        }
    }



    IEnumerator ClickPerSec()
    {
        while (true)
        {
            energy += (long)allEnergyPerSec;
            yield return new WaitForSeconds(1);
        }

    }


    public void ShopPan_ShowAndHide()   
    {

        shopPan.SetActive(true);
        closeShopButton.SetActive(true);
        WheelOnMain = scriptWheelShop.ANWheel;
        WheelOnMain.SetActive(false);
        scriptOpenHamsters.NowHamster.SetActive(false);
        StaticPanel.SetActive(true);
        scriptSwitchShopPans.ShopPan_2.SetActive(false);
        scriptSwitchShopPans.ShopPan_3.SetActive(false);
        BoostAir.SetActive(false);
        
        shadow_4.SetActive(false);
    }
    public void CloseShop()
    {
        shopPan.SetActive(false);
        closeShopButton.SetActive(false);
        WheelOnMain = scriptWheelShop.ANWheel;
        WheelOnMain.SetActive(true);
        scriptOpenHamsters.NowHamster.SetActive(true) ;
        StaticPanel.SetActive(false);
        if (allItems[5].GetComponent<Item>().priceItem > 1200000)
        {
            BoostAir.SetActive(true);
            
            shadow_4.SetActive(true);
        }
    }

    public void ButtonClick()
    {
        energy += (long)clickEnergy;
        
    }
  
    void Update()
    {
        finalEnergy = energy;
        energyText.text = finalEnergy.ToString();
        moneyText.text = money.ToString();
        MoneyRate.text = exchangeRate.ToString();
        perClick.text = clickEnergy.ToString();
        
        perSec.text = Math.Round(allEnergyPerSec).ToString();
        RefresherNumbers();
        CheckSeconds();
        

    }

    public void TradePanOpen()
    {
        TradePan.SetActive(true);
        closeTradeButton.SetActive(true);
        WheelOnMain = scriptWheelShop.ANWheel;
        WheelOnMain.SetActive(false);
        scriptOpenHamsters.NowHamster.SetActive(false);
        exchangeButton.GetComponent<Button>().interactable = false;
        shopButton.GetComponent<Button>().interactable = false;
        wheelButton.GetComponent<Button>().interactable = false;

    }
    public void TradePanClose()
    {
        TradePan.SetActive(false);
        closeTradeButton.SetActive(false);
        WheelOnMain = scriptWheelShop.ANWheel;
        WheelOnMain.SetActive(true);
        scriptOpenHamsters.NowHamster.SetActive(true);
        exchangeButton.GetComponent<Button>().interactable = true;
        shopButton.GetComponent<Button>().interactable = true;
        wheelButton.GetComponent<Button>().interactable = true;
    }
 
    public void TradeEnergyToMoney()
    {
        if (finalEnergy >= 1)
        {
            money += (long)(finalEnergy * exchangeRate);
            finalEnergy = 0;
            energy = 0;
            
        }

    }
    public void RefresherNumbers()
    {
        if (money >= 1000)
        {
            moneyText.text = Math.Round((double)money / 1000, 2).ToString() + "тыс.";
        }
        if (money >= 1000000)
        {
            moneyText.text = Math.Round((double)money / 1000000, 2).ToString() + "млн.";
        }
        if (money >= 1000000000)
        {
            moneyText.text = Math.Round((double)money / 1000000000, 2).ToString() + "млрд.";
        }



        if (energy >= 1000)
        {
            energyText.text = Math.Round((double)energy / 1000, 2).ToString() + "тыс.";
        }
        if (energy >= 1000000)
        {
            energyText.text = Math.Round((double)energy / 1000000, 2).ToString() + "млн.";
        }
        if (energy >=1000000000)
        {
            energyText.text = Math.Round((double)energy / 1000000000, 2).ToString() + "млрд.";
        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            exchangeSeconds -= 1;
        }
        
    }
    public void CheckSeconds()
    {
        if (exchangeSeconds == 0)
        {
            exchangeSeconds = 30 - scriptOpenHamsters.subtractSec;



            if (scriptOpenHamsters.Hamsters[1].GetComponent<HamstersScript>().OpenedButton == true)
            {
                exchangeRate = UnityEngine.Random.Range(1.00f, 3.00f) * 1.1;
            }
            else
            {
                exchangeRate = UnityEngine.Random.Range(1.00f, 3.00f);
            }
            exchangeRate = Math.Round(exchangeRate, 2);



        }
    
        if (exchangeSeconds % 60 < 10)
        {
            ForMethod.text =( "0" + exchangeSeconds % 60).ToString();
        }
        else
        {
            ForMethod.text = (exchangeSeconds % 60).ToString();
        }
        ExchangeSecondsText.text = (exchangeSeconds / 60 + ":" + ForMethod.text).ToString();
    }


    public void OpenWheelPan()
    {
        
        WheelPan.SetActive(true);
        scriptOpenHamsters.NowHamster.SetActive(false);
        WheelOnMain = scriptWheelShop.ANWheel;
        WheelOnMain.SetActive(false);
        if (allItems[5].GetComponent<Item>().priceItem > 2500000)
        {
            BoostAir.SetActive(false);
            shadow_4.SetActive(false);
        }


    }
    public void CloseWheelPan()
    {
        WheelPan.SetActive(false);
        scriptOpenHamsters.NowHamster.SetActive(true);
        WheelOnMain = scriptWheelShop.ANWheel;
        WheelOnMain.SetActive(true);
        if (allItems[5].GetComponent<Item>().priceItem > 2500000)
        {
            BoostAir.SetActive(true);
            shadow_4.SetActive(true);
        }
    }

    private void OnApplicationQuit()
    {
        sv.energy = energy;
        sv.money =  money;
        sv.allEnergyPerSec = allEnergyPerSec;
        sv.clickEnergy = clickEnergy;
        sv.finalItemPrice = finalItemPrice;
        sv.finalEnergy = finalEnergy;
        sv.exchangeRate = exchangeRate;
        sv.energyPerSec = energyPerSec;
        sv.exchangeSeconds = exchangeSeconds;
        sv.priceItem = new double[allItems.Length];
        sv.priceItem_2 = new double[allItems_2.Length];
        sv.list_1 = list_1;
        sv.list_2 = list_2;


        sv.info = new WheelSkin[scriptWheelShop.info.Length];
        sv.priceWheel = new double[scriptWheelShop.info.Length];
        sv.HamstersIsChosen = new bool[scriptOpenHamsters.Hamsters.Length];
        sv.HamstersInStock = new bool[scriptOpenHamsters.Hamsters.Length];

        for (int i = 0; i < allItems.Length; i++)
        {
            sv.priceItem[i] = allItems[i].GetComponent<Item>().priceItem;  
        }
        for (int i = 0; i < allItems_2.Length; i++)
        {
            sv.priceItem_2[i] = allItems_2[i].GetComponent<Item>().priceItem_2;
        }





        sv.WheelList = scriptWheelShop.WheelList;
        for (int i = 0; i < scriptWheelShop.info.Length; i++)
        {
            sv.info[i] = scriptWheelShop.info[i];
        }
        for (int i = 0; i < scriptWheelShop.info.Length; i++)
        {
            sv.priceWheel[i] = scriptWheelShop.allWheels[i].GetComponent<Wheel>().priceWheel;
        }
        for (int i = 0; i < scriptOpenHamsters.Hamsters.Length; i++)
        {
            sv.HamstersIsChosen[i] = scriptOpenHamsters.Hamsters[i].GetComponent<HamstersScript>().isChosen;
            sv.HamstersInStock[i] = scriptOpenHamsters.Hamsters[i].GetComponent<HamstersScript>().inStock;
            //if (scriptOpenHamsters.Hamsters[i].GetComponent<HamstersScript>().inStock == true)
            //{
            //    sv.HamstersAvatars1[i] = scriptOpenHamsters.Hamsters[i].GetComponent<HamstersScript>().imageHamster2;
            //}
            
        }
        sv.subtractSec = scriptOpenHamsters.subtractSec;




        PlayerPrefs.SetString("SVMainMenu", JsonUtility.ToJson(sv));
    }

   




}

[Serializable]

public class SaveMainMenu
{

    public List<string> boughtItems = new List<string>();
    public long energy;
    public long money;
    public double allEnergyPerSec;   /*scriptMainMenu*/
    public double clickEnergy;
    public double finalItemPrice;
    public long finalEnergy;
    public double exchangeRate;
    public int energyPerSec;
    public int exchangeSeconds;

    public List<string> list_1 = new List<string>();
    public List<string> list_2 = new List<string>();

    public double [] priceItem;
    public double [] priceItem_2;  /*criptItem*/


    public List<string> WheelList = new List<string>();                /*scriptWheel*/
    public WheelSkin[] info;
    public double[] priceWheel;

    public bool [] HamstersIsChosen;
    public bool [] HamstersInStock;
    public int subtractSec;
    //public GameObject[] HamstersAvatars1;
    //public GameObject[] HamstersAvatars2;






}

