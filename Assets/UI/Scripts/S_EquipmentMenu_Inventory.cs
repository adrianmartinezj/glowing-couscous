using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class S_EquipmentMenu_Inventory : MonoBehaviour
{
    // Start is called before the first frame update

    // Private
    [SerializeField]
    private GameObject OverviewButton;
    public enum Tab { Overview, Weapons, Armor, Modifiers};
    public Tab CurrentTab { get; private set; } = Tab.Overview;
    void Start()
    {
        if (!OverviewButton)
        {
            // Slower lookup to find if not already set
            OverviewButton = GameObject.Find("OverviewButton");
            Assert.IsNotNull(OverviewButton);
        }
        OverviewButton.GetComponent<Button>().Select();
    }

    public void TabClick()
    {
        Debug.Log("currentObject: " + EventSystem.current.currentSelectedGameObject);
        GameObject CurrentTabObject = EventSystem.current.currentSelectedGameObject;
        switch(CurrentTabObject.name)
        {
            case "OverviewButton":
                CurrentTab = Tab.Overview;
                break;
            case "WeaponsButton":
                CurrentTab = Tab.Weapons;
                break;
            case "ArmorButton":
                CurrentTab = Tab.Armor;
                break;
            case "ModifiersButton":
                CurrentTab = Tab.Modifiers;
                break;
            default:
                Debug.Log("Something went wrong: Tab does not exist");
                break;
        }
        Debug.Log("CurrentTab: " + CurrentTab);
    }

    public void SelectTab(Tab tab)
    {
        string buttonName = "";
        switch (tab)
        {
            case Tab.Overview:
                buttonName = "OverviewButton";
                break;
            case Tab.Weapons:
                buttonName = "WeaponsButton";
                break;
            case Tab.Armor:
                buttonName = "ArmorButton";
                break;
            case Tab.Modifiers:
                buttonName = "ModifiersButton";
                break;
            default:
                Debug.Log("Something went wrong: Tab does not exist");
                break;
        }
        GameObject.Find(buttonName).GetComponent<Button>().Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
