using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtons : MonoBehaviour
{
    public void ExitYes()
    {
        Application.Quit();
    }
    public void ExitNo()
    {
        gameObject.SetActive(false);
    }
}
