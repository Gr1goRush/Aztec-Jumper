using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text moneyText;
    [SerializeField] Button item1, item2, item3, item4;
    [SerializeField] Sprite itemLock2, itemLock3, itemLock4, itemBuy1, itemBuy2, itemBuy3, itemBuy4, itemSelect1, itemSelect2, itemSelect3, itemSelect4;
     public string it1Status;
    public string it2Status ;
    public string it3Status ;
   public string it4Status ;

    void Start()
    {
               StartLoad();

    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = PlayerPrefs.GetInt("coin").ToString();
    }
    public void Item1Button()
    {
        if (it1Status == "lock" && PlayerPrefs.GetInt("coin")>=0) 
        {
            PlayerPrefs.SetInt("coin",PlayerPrefs.GetInt("coin")-0);
            it1Status = "buying";
            item1.GetComponent<Image>().sprite = itemBuy1;
        }
        else if (it1Status == "buying")
        {
            NewSelect();
            it1Status = "active";
            item1.GetComponent<Image>().sprite = itemSelect1;
            PlayerPrefs.SetInt("activePlayer",1);
        }
        SaveRezults();
    }


    public void Item2Button()
    {
     
        if (it2Status == "lock" && PlayerPrefs.GetInt("coin") >= 200)
        {
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 200);
            it2Status = "buying";
            item2.GetComponent<Image>().sprite = itemBuy2;
        }
        else if (it2Status == "buying")
        {
            NewSelect();
            it2Status = "active";
            item2.GetComponent<Image>().sprite = itemSelect2;
            PlayerPrefs.SetInt("activePlayer", 2);
        }
        SaveRezults();
    }


    public void Item3Button()
    {
        if (it3Status == "lock" && PlayerPrefs.GetInt("coin") >= 300)
        {

            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 300);
            it3Status = "buying";
            item3.GetComponent<Image>().sprite = itemBuy3;
        }
        else if (it3Status == "buying")
        {
            NewSelect();
            it3Status = "active";
            item3.GetComponent<Image>().sprite = itemSelect3;
            PlayerPrefs.SetInt("activePlayer", 3);
        }
        SaveRezults();
    }


    public void Item4Button()
    {
        if (it4Status == "lock" && PlayerPrefs.GetInt("coin") >= 400)
        {
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 400);
            it4Status = "buying";
            item4.GetComponent<Image>().sprite = itemBuy4;
        }
        else if (it4Status == "buying")
        {
            NewSelect();
            it4Status = "active";
            item4.GetComponent<Image>().sprite = itemSelect4;
            PlayerPrefs.SetInt("activePlayer", 4);
        }
        SaveRezults();
    }

    public void NewSelect()
    {
        if (it1Status == "active"|| it1Status == "buying")
        {
            item1.GetComponent<Image>().sprite = itemBuy1;
            it1Status = "buying";
        }

        if (it2Status == "active" || it2Status == "buying")
        {
            item2.GetComponent<Image>().sprite = itemBuy2;
            it2Status = "buying";
        }
        if (it3Status == "active" || it3Status == "buying")
        {
            item3.GetComponent<Image>().sprite = itemBuy3;
            it3Status = "buying";
        }
        if (it4Status == "active" || it4Status == "buying")
        {
            item4.GetComponent<Image>().sprite = itemBuy4;
            it4Status = "buying";
        }
    }
    public void SaveRezults()
    {
        PlayerPrefs.SetString("it1",it1Status);
        PlayerPrefs.SetString("it2", it2Status);
        PlayerPrefs.SetString("it3", it3Status);
        PlayerPrefs.SetString("it4", it4Status);
    }
    public void StartLoad()
    {
        if (PlayerPrefs.GetInt("FirstTime") != 1)
        {
            it1Status = "active";
            it2Status = "lock";
            it3Status = "lock";
            it4Status = "lock";
            PlayerPrefs.SetInt("FirstTime", 1);
        }
        else
        {
            it1Status = PlayerPrefs.GetString("it1");
            it2Status = PlayerPrefs.GetString("it2");
            it3Status = PlayerPrefs.GetString("it3");
            it4Status = PlayerPrefs.GetString("it4");
        }
       
        StartLoadItem1();
        StartLoadItem2();
        StartLoadItem3();
        StartLoadItem4();

    }
    public void StartLoadItem1()
    {
        if (it1Status == "lock")
        {
            item1.GetComponent<Image>().sprite = itemBuy1;
        }
         if (it1Status == "buying")
        {
            item1.GetComponent<Image>().sprite = itemBuy1;
        }
        if (it1Status == "active")
        {
            item1.GetComponent<Image>().sprite = itemSelect1 ;
            PlayerPrefs.SetInt("activePlayer", 1);
        }
    }
    public void StartLoadItem2()
    {
        if (it2Status == "lock")
        {
            item2.GetComponent<Image>().sprite = itemLock2;
        }
        if (it2Status == "buying")
        {
            item2.GetComponent<Image>().sprite = itemBuy2;
        }
        if (it2Status == "active")
        {
            item2.GetComponent<Image>().sprite = itemSelect2;
            PlayerPrefs.SetInt("activePlayer", 2);
        }
    }

    public void StartLoadItem3()
    {
        if (it3Status == "lock")
        {
            item3.GetComponent<Image>().sprite = itemLock3;
        }
        if (it3Status == "buying")
        {
            item3.GetComponent<Image>().sprite = itemBuy3;
        }
        if (it3Status == "active")
        {
            item3.GetComponent<Image>().sprite = itemSelect3;
            PlayerPrefs.SetInt("activePlayer", 3);
        }
    }
    public void StartLoadItem4()
    {
        if (it4Status == "lock")
        {
            item4.GetComponent<Image>().sprite = itemLock4;
        }
        if (it4Status == "buying")
        {
            item4.GetComponent<Image>().sprite = itemBuy4;
        }
        if (it4Status == "active")
        {
            item4.GetComponent<Image>().sprite = itemSelect4;
            PlayerPrefs.SetInt("activePlayer", 4);
        }
    }
}
