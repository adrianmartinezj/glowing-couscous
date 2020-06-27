using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class S_MainMenu : MonoBehaviour
{
    // Public
    public delegate void ContinueAction();
    public static event ContinueAction OnContinue;
    public CanvasGroup ChildCanvasGroup;
    // Private
    private GameObject ChildPanel;
    private void Awake()
    {
        ChildPanel = this.gameObject.transform.GetChild(0).gameObject;
        ChildCanvasGroup = ChildPanel.GetComponent<CanvasGroup>();
        Assert.IsNotNull(ChildCanvasGroup);
    }
    public void Continue()
    {
        Debug.Log("Continue!");
        OnContinue();
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
