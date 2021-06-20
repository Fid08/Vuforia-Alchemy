using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeController : MonoBehaviour
{
    [Header("Базовые компоненты")]
    public GameObject MandrakeExtract;
    public GameObject UniversalSolution;
    public GameObject MountainRoseSeeds;


    [Header("Инвентарь")]
    public GameObject PurificationPotion;
    public GameObject EternalRoseSeeds;
    public GameObject LiveBarrier;

    [Header("Технические объекты")]
    
    public Text EffectText;
    
    private Text CounterText;
     private AudioSource SuccessSound;
     private AudioSource FailSound;
     
     public  bool SuccessPlay;
     private GameObject go_slot;
     private Slot c_slot;


    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        SuccessSound = this.GetComponent<AudioSource>();
        go_slot = GameObject.Find("Slot1");
        c_slot = go_slot.GetComponent<Slot>();

        
    }

    // Update is called once per frame
    void Update()
    {
        RecipePurificationPotion();
        RecipeEternalRoseSeeds();
        RecipeLiveBarrier();
    }
    void RecipePurificationPotion()
    {

        if(MandrakeExtract.activeSelf&&UniversalSolution.activeSelf)
        {
            c_slot.Disableator();
            PurificationPotion.SetActive(true);
            UniversalSolution.SetActive(false);
            MandrakeExtract.SetActive(false);

            Debug.Log("Purification Poition created");

            //оповещение
            EffectText.text += " <color=red>Зелье Очищения</color>";
            
            //Увелечение количества айтема в инвентаре
            GameObject Counter = GameObject.Find("PPcounter");
            CounterText = Counter.GetComponent<Text>();
            int sum = int.Parse(CounterText.text); 
            sum+=1;
            CounterText.text = sum.ToString();

            
            StartCoroutine("Success");
        
        
        }

    }
    void RecipeEternalRoseSeeds()

    {
        IngredientStatus MRSStatus = MountainRoseSeeds.GetComponent<IngredientStatus>();
        if(MountainRoseSeeds.activeSelf&&MandrakeExtract.activeSelf&&MRSStatus.Cold == true)
        
        {
            c_slot.Disableator();

             EternalRoseSeeds.SetActive(true);
             MountainRoseSeeds.SetActive(false);
             MandrakeExtract.SetActive(false);

             Debug.Log("Eteternal Rose Seeds created");
             EffectText.text += " <color=red>Семена вечной розы</color>";

             GameObject Counter = GameObject.Find("ERScounter");
             CounterText = Counter.GetComponent<Text>();
             int sum = int.Parse(CounterText.text); 
             sum+=1;
             CounterText.text = sum.ToString();

             
             
            
             

             MRSStatus.Neutral();

             StartCoroutine("Success");
            
            

        }


    } 
    void RecipeLiveBarrier()
    {

        if(PurificationPotion.activeSelf&&EternalRoseSeeds.activeSelf)
        {
    
            GameObject PPGameObject = GameObject.Find("CanvasPP");
            GameObject ERSGameObject = GameObject.Find("CanvasERS");
            GameObject[] Ingredients = GameObject.FindGameObjectsWithTag("Active");

            if(PPGameObject.activeSelf&&ERSGameObject.activeSelf)
            {
                
                c_slot.Disableator();
                
            
             LiveBarrier.SetActive(true);
             PPGameObject.SetActive(false);
             ERSGameObject.SetActive(false);

             Debug.Log("Live Barrier created");

             //оповещение
             EffectText.text += " <color=yellow>Живой Барьер</color>";

        
            
             //Увелечение количества айтема в инвентаре
             GameObject Counter = GameObject.Find("LBcounter");
             CounterText = Counter.GetComponent<Text>();
             int sum = int.Parse(CounterText.text); 
             sum+=1;
             CounterText.text = sum.ToString();
            
            
            StartCoroutine("Success");
            }


        }



    }

    void PanelReset()
    {
        GameObject [] buttonsUse = GameObject.FindGameObjectsWithTag("useButton");
        GameObject [] buttonsRem = GameObject.FindGameObjectsWithTag("remButton");
        for(int i=0;i<buttonsUse.Length;i++)
        {
          buttonsUse[i].SetActive(true);
          buttonsRem[i].SetActive(false);
        }
    }




    IEnumerator Success()
    {
        EffectText.enabled = true;
        SuccessSound.Play();

        SuccessPlay =true;
        
        yield return new WaitForSeconds(2);  
        SuccessPlay =false;
        EffectText.text = "Успех! Вы создали";
        EffectText.enabled = false;
        

        
    }


    

    




}
