using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject menu;

    public int GoalMoney;

    public GameObject WinPanel;
    public GameObject LosePanel;

    public Text Goal;
    public Text MoneyCounter;

    

    
    
    void Start()
    {
        Goal.text += GoalMoney.ToString();
    }

    
    void Update()
    {
       int i_MoneyCounter = int.Parse(MoneyCounter.text);
       if(i_MoneyCounter >=GoalMoney)
       {
           WinPanel.SetActive(true);
           Time.timeScale = 0;
       }

        if(Input.GetKey(KeyCode.Escape))
        {
           
            menu.SetActive(true);

        }
    }
    public void Lose()
    {
        Time.timeScale = 0;
        LosePanel.SetActive(true);
    }
    
    
    
}
