using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HamstersScript : MonoBehaviour
{
    public OpenHamsters scriptOpenHamsters;

    public GameObject OpenButton;
    public GameObject OpenedButton;
    public string HamsterName;
    public int Count;
    public int firstCount;
    public GameObject imageHamster;
    public GameObject imageHamster2;
    public GameObject Hamster1;
    public GameObject Hamster2;
    public bool isChosen;
    public bool inStock;
    public int HamsterCheck;


    public void OpenHamsters()
    {
        scriptOpenHamsters.OpenButton = OpenButton;
        scriptOpenHamsters.OpenedButton = OpenedButton;
        scriptOpenHamsters.HamsterName = HamsterName;
        scriptOpenHamsters.Count = Count;
        scriptOpenHamsters.firstCount = firstCount;
        scriptOpenHamsters.imageHamster = imageHamster;
        scriptOpenHamsters.imageHamster2 = imageHamster2;
        scriptOpenHamsters.Hamster1 = Hamster1;
        scriptOpenHamsters.Hamster2 = Hamster2;
        scriptOpenHamsters.isChosen = isChosen;
        scriptOpenHamsters.inStock = inStock;

        scriptOpenHamsters.OpenHamster();
        scriptOpenHamsters.For1stHamster();
        scriptOpenHamsters.For2ndHamster();
        scriptOpenHamsters.For3dHamster();
        scriptOpenHamsters.HamsterCheck = HamsterCheck;

    }
}
