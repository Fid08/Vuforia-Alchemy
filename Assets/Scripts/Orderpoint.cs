using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orderpoint : MonoBehaviour
{
    public Text OrderText;

    public bool NewOrder;
    // Start is called before the first frame update
    void Start()
    {
        NewOrder = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(NewOrder == true)
        {
            StartCoroutine("OrderGenerator");
        }
    }
    IEnumerator OrderGenerator()
    {
        yield return new WaitForSeconds(5);  

        

        NewOrder = false;

    }
}
