using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class S_MainMenu : MonoBehaviour
{
    private const float FADE_TIME = 0.4f;
    [SerializeField]
    private GameObject ChildPanel;
    private CanvasGroup ChildCanvasGroup;
    private void Awake()
    {
        ChildCanvasGroup = ChildPanel.GetComponent<CanvasGroup>();
        Assert.IsNotNull(ChildCanvasGroup);
    }
    public void Continue()
    {
        Debug.Log("Continue!");
        CleanupElement();
    }

    public void NewGame()
    {
        Debug.Log("NewGame!");
        CleanupElement();
    }

    public void Options()
    {
        Debug.Log("Options!");
        CleanupElement();
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    private void CleanupElement()
    {
        StartCoroutine(FadeCanvas());
    }

    private IEnumerator FadeCanvas()
    {
        float deltaSeconds = 0.0f;
        while (deltaSeconds < FADE_TIME)
        {
            deltaSeconds += Time.deltaTime;
            ChildCanvasGroup.alpha = Mathf.Lerp(1, 0, deltaSeconds / FADE_TIME);
            if (ChildCanvasGroup.alpha == 0)
            {
                Destroy(this.gameObject);
            }
            yield return null;
        }
    }
}
