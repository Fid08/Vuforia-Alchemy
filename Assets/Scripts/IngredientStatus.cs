using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientStatus : MonoBehaviour
{
    public int price;
    public GameObject CoolingStone;
    public GameObject HeatingStone;
    
    
    public GameObject CoolingTrigger;

    public GameObject HeatingTrigger;
   
    private GameObject _MoneyCounter;

   
    public bool Hot;
    public bool Cold;
    public bool Sold;

    
    // Start is called before the first frame update
    void Start()
    {
        HeatingStone.SetActive(false);
        CoolingStone.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        Cooling();
        Heating();
    }



    void Cooling()
    {
        if(CoolingTrigger.activeSelf&&gameObject.activeSelf)
        {
            Cold = true;
            Hot=false;
            HeatingStone.SetActive(false);
            CoolingStone.SetActive(true);


        }
       

    }
    void Heating()
    {
        if(HeatingTrigger.activeSelf&&gameObject.activeSelf)
        {
            Cold = false;
            Hot=true;
            CoolingStone.SetActive(false);
            HeatingStone.SetActive(true);

        }

        
        
    }
    public void Neutral()
    {
        CoolingStone.SetActive(false);
        HeatingStone.SetActive(false);
        Cold = false;
        Hot=false;

    }

    public void Sell()
    {
    
        _MoneyCounter = GameObject.Find("MoneyCounter");
        Text TotalMoney = _MoneyCounter.GetComponent<Text>();
        int i_TotalMoney = int.Parse(TotalMoney.text);
        i_TotalMoney +=price;
        TotalMoney.text = i_TotalMoney.ToString();
        Sold = true; 

    }
}
