using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PauseMenu : MonoBehaviour
{
    // Public
    public static event Action OnResume;
    public static event Action OnMainMenu;

    public void Resume()
    {
        OnResume();
    }
    public void MainMenu()
    {
        OnMainMenu();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
