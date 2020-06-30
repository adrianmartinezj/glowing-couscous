using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

public class S_Game_UI_Manager : MonoBehaviour
{

    // Private
    [SerializeField]
    private GameObject MainMenuObjectType;
    [SerializeField]
    private GameObject EquipmentMenuObjectType;
    [SerializeField]
    private GameObject PauseMenuObjectType;
    private GameObject MainMenu;
    private GameObject EquipmentMenu;
    private GameObject PauseMenu;
    private const float FADE_TIME = 0.4f;
    private delegate void Callback();
    public static S_Game_UI_Manager Instance = null;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        MainMenu = Instantiate(MainMenuObjectType);
        S_MainMenu.OnContinue += ContinueHandler;
        S_MainMenu.OnMenuDestroy += OnMainMenuDestroy;
        S_PauseMenu.OnMainMenu += BackToMainMenu;
        S_PauseMenu.OnResume += Resume;
    }

    private void Resume()
    {
        Time.timeScale = 1f;

        Destroy(PauseMenu);
        // Quick fix to ensure the tab remains selected
        if (EquipmentMenu)
        {
            S_EquipmentMenu_Inventory EquipmentMenu_Inventory = EquipmentMenu.GetComponentInChildren<S_EquipmentMenu_Inventory>();
            EquipmentMenu_Inventory.SelectTab(EquipmentMenu_Inventory.CurrentTab);
        }
    }

    private void OnMainMenuDestroy()
    {
        // Cleanup because memory leaks
        S_MainMenu.OnContinue -= ContinueHandler;
    }

    private void ContinueHandler()
    {
        DatabaseSystem.testFunc();
        StartCoroutine(FadeOutCoroutine(MainMenu.GetComponent<S_MainMenu>().ChildCanvasGroup, MainMenu, () => 
        { 
            // Create a lambda for instantiating our equipment menu at the end
            EquipmentMenu = Instantiate(EquipmentMenuObjectType);
            GameObject EquipmentChildPanel = EquipmentMenu.transform.GetChild(0).gameObject;
            Assert.IsNotNull(EquipmentChildPanel);
            StartCoroutine(FadeInCoroutine(EquipmentChildPanel.GetComponent<CanvasGroup>()));
        }));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)
            && MainMenu == null
            && PauseMenu == null)
        {
            Pause();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        PauseMenu = Instantiate(PauseMenuObjectType);
    }

    private void BackToMainMenu()
    {
        throw new NotImplementedException();
    }

    private IEnumerator FadeOutCoroutine(CanvasGroup canvasGroup, GameObject parent, Callback cb=null)
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

    private IEnumerator FadeInCoroutine(CanvasGroup canvasGroup, Callback cb = null)
    {
        float deltaSeconds = 0.0f;
        while (deltaSeconds < FADE_TIME)
        {
            deltaSeconds += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, deltaSeconds / FADE_TIME);
            if (canvasGroup.alpha == 1)
            {
                // If there's a callback present, use it
                cb?.Invoke();
            }
            yield return null;
        }
    }
}
