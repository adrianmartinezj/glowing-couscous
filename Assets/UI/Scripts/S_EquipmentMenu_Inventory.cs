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
    [SerializeField]
    private GameObject Entry;
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

        LoadPlayerInventory();
    }

    private void LoadPlayerInventory()
    {
        // Get Player inventory
        GameObject logic = GameObject.FindGameObjectWithTag("Logic");
        GameObject player = logic.GetComponent<S_Game_Logic>().Player;
        Assert.IsNotNull(player);
        GameObject content = GameObject.Find("Content");
        ControllableCharacter character = player.GetComponent<ControllableCharacter>();
        for (int i = 0; i < character.inventory.Items.Count; i++)
        {
            var wep = character.inventory.Items[i];
            if (wep.GetType() == typeof(Weapon))
            {
                GameObject entry = Instantiate(Entry, content.transform);
                // Get text of entry
                RectTransform rect = entry.transform.GetComponent<RectTransform>();
                float origHeight = rect.sizeDelta.y;
                float offset = -(rect.sizeDelta.y * i);
                rect.offsetMax = new Vector2(0, offset);
                rect.sizeDelta = new Vector2(0, origHeight);

                entry.transform.GetChild(0).GetComponent<Text>().text = ((Weapon)wep).name;
            }
        }
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
