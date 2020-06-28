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
    private enum Tab { Overview, Weapons, Armor, Modifiers};
    private Tab currentTab = Tab.Overview;
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
        GameObject currentTabObject = EventSystem.current.currentSelectedGameObject;
        switch(currentTabObject.name)
        {
            case "OverviewButton":
                currentTab = Tab.Overview;
                break;
            case "WeaponsButton":
                currentTab = Tab.Weapons;
                break;
            case "ArmorButton":
                currentTab = Tab.Armor;
                break;
            case "ModifiersButton":
                currentTab = Tab.Modifiers;
                break;
            default:
                Debug.Log("Something went wrong: Tab does not exist");
                break;
        }
        Debug.Log("currentTab: " + currentTab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
