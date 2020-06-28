using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class S_EquipmentMenu_Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject DefaultSelectedButton;
    void Start()
    {
        if (DefaultSelectedButton)
        {
            //EventSystem.current.SetSelectedGameObject(DefaultSelectedButton);
            DefaultSelectedButton.GetComponent<Button>().Select();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
