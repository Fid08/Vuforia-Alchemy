using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Slot : MonoBehaviour
{
    public bool Active;

    private GameObject _ingredient;
    private GameObject _ingredient2;
    private GameObject _ingredientCanvas;
    private GameObject _ingredientCanvas2;

     
    public void Activator()
    {
        if(Active==true)
        {
            GameObject _slot2 = GameObject.Find("Slot2");
            _ingredientCanvas2 = GameObject.FindGameObjectWithTag("IngredientCanvas");
           _ingredientCanvas2.transform.SetParent(_slot2.transform,true);
           _ingredient2 = GameObject.FindGameObjectWithTag("ingredient");
           _ingredient2.transform.position = _slot2.transform.position; 
           
           
        }
        else
        {
            
        _ingredientCanvas = GameObject.FindGameObjectWithTag("IngredientCanvas");
        _ingredientCanvas.tag = "ActiveCanvas";
        _ingredientCanvas.transform.SetParent(gameObject.transform,true);
        _ingredient = GameObject.FindGameObjectWithTag("ingredient");
        _ingredient.transform.position = this.transform.position;
        _ingredient.tag="Active";
        
        Active=true;
           

        }

    }
    public void Disableator()
    {
        Active=false;
        _ingredientCanvas.transform.SetParent(null);
        _ingredient.tag="ingredient";
        _ingredient2.tag="ingredient";
        _ingredientCanvas.tag = "IngredientCanvas";
        Active =false;

    }

}
