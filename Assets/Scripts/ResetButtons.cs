using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtons : MonoBehaviour
{
    public GameObject Inventory;

    public GameObject UseButton;
    public GameObject RemoveButton;

    
    
    private RecipeController RC;
    // Start is called before the first frame update
    void Start()
    {
         RC = Inventory.GetComponent<RecipeController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(RC.SuccessPlay ==true)
        {
            RemoveButton.SetActive(false);
            UseButton.SetActive(true);
        }

        
        
    }
}
