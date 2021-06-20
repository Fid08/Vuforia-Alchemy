using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonblock : MonoBehaviour
{
    public Text _text;

    public Button _use;
    public Button _sell;
    
    
    void Update()
    {
        
        int i_counter =int.Parse(_text.text);
        if(i_counter ==0)
        {
            _use.gameObject.SetActive(false);
            _sell.gameObject.SetActive(false);

        }
        else
        {
             _use.gameObject.SetActive(true);
            _sell.gameObject.SetActive(true);

        }

    }
    public void CounterChange()
    {
        int i_counter =int.Parse(_text.text);
        i_counter -=1;
        _text.text = i_counter.ToString();
    }
    public void CounterPlus()
    {
        int i_counter =int.Parse(_text.text);
        i_counter +=1;
        _text.text = i_counter.ToString();
    }
    
}
