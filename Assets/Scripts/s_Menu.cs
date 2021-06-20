using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s_Menu : MonoBehaviour
{
    

    public  void Play()
    {
        SceneManager.LoadScene(1);
        
    }
    
    public void Exit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        Application.Quit(0);
    }
}
