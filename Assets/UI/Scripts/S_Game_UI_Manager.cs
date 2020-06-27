using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Game_UI_Manager : MonoBehaviour
{

    // Private
    [SerializeField]
    private GameObject MainMenuObjectType;
    [SerializeField]
    private GameObject EquipmentMenuObjectType;
    private GameObject MainMenu;
    private GameObject EquipmentMenu;
    private const float FADE_TIME = 0.4f;
    private delegate void Callback();

    // Start is called before the first frame update
    void Start()
    {
        MainMenu = Instantiate(MainMenuObjectType);
        S_MainMenu.OnContinue += ContinueHandler;
    }

    private void ContinueHandler()
    {

        StartCoroutine(FadeOut(MainMenu.GetComponent<S_MainMenu>().ChildCanvasGroup, MainMenu, () => 
        { 
            EquipmentMenu = Instantiate(EquipmentMenuObjectType);
        }));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator FadeOut(CanvasGroup canvasGroup, GameObject parent, Callback cb=null)
    {
        float deltaSeconds = 0.0f;
        while (deltaSeconds < FADE_TIME)
        {
            deltaSeconds += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, deltaSeconds / FADE_TIME);
            if (canvasGroup.alpha == 0)
            {
                Destroy(parent);
                // If there's a callback present, use it
                cb?.Invoke();
            }
            yield return null;
        }
    }
}
