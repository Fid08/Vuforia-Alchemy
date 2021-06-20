using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderDealer : MonoBehaviour
{
    [Header("Кнопки")]

    public AudioSource SoundComplited;

    public IngredientStatus SellPP;
    public IngredientStatus SellERC;
    public IngredientStatus SellLB;

    private IngredientStatus ISL;

    public bool ActiveOrder;


    private GameObject OrderButton;
    
    public Text order;
    public Text timer;



    private float OrderTimer;

    private bool StartTimer;
    private bool StopTimer;


    
    void Start()
    {
        OrderButton = GameObject.Find("OrderButton");
    }

    void Update()
    {
        
        //OrderGenerator();
        Timer();
        OrderComplited();
        
    }

    void Timer()
    {
        if(StartTimer==true)
        {
            
           OrderTimer -=Time.deltaTime;
           int i_OrderTimer = (int)OrderTimer;
           timer.text = i_OrderTimer.ToString();
        }
        if(StopTimer == true)
        {
            StartTimer = false;
            OrderTimer = 60;
            timer.text ="Timer";

        }
        if(timer.text =="0")
        {
            Time.timeScale = 0;
            GameObject ARC = GameObject.Find("ARCamera");
            GameController _gameController = ARC.GetComponent<GameController>();
            _gameController.Lose();

        }


    }
    public void OrderGenerator()
    {
        
        
        
         ActiveOrder = true;
         
         float number = Random.Range(1,4);
         OrderTimer = Random.Range(30,60);
        
        switch(number)
        {

            case 1f:
            order.text += "<color=red> Зелье Очищения</color>";
            StartTimer=true;
            StopTimer=false;
            ISL = SellPP;
            break;
            
            case 2f:
            order.text += "<color=red> Семена вечной розы</color>";
            StartTimer=true;
            StopTimer=false;
            ISL = SellERC;
            
            break;

            case 3f:
            order.text += " <color=yellow> Живой барьер</color>";
            ISL = SellLB;
            StartTimer=true;
            StopTimer=false;
            break;
            

            
        }
        
        

        
    }
    void OrderComplited()
    {
        if(StartTimer==true)
        {
        if(ISL.Sold ==true)
        {
            StopTimer=true;
            ActiveOrder = false;
            order.text = "Заказ:";
            ISL.Sold =false;
            SoundComplited.Play();
            GameObject CancelButton = GameObject.Find("CancelButton");
            CancelButton.SetActive(false);
            OrderButton.SetActive(true);
        }
        }

    }

    public void OrderCancel()
    {
        StopTimer=true;
        ActiveOrder = false;
        order.text = "Заказ:";
        ISL.Sold =false;

        GameObject _MoneyCounter = GameObject.Find("MoneyCounter");
        Text TotalMoney = _MoneyCounter.GetComponent<Text>();
        int i_TotalMoney = int.Parse(TotalMoney.text);
        i_TotalMoney -=100;
        TotalMoney.text = i_TotalMoney.ToString();
    }
}
