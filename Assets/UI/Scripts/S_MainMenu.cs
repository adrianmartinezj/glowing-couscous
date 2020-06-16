using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MainMenu : MonoBehaviour
{
    public void Continue()
    {
        Debug.Log("Continue!");
    }

    public void NewGame()
    {
        Debug.Log("NewGame!");
    }

    public void Options()
    {
        Debug.Log("Options!");
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
