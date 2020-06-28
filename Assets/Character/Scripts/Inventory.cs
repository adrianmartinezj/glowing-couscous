using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    // Public
    public List<GameObject> Items { get; private set; }

    public Inventory()
    {
        Debug.Log("Constructing inventory");
    }

    public void AddItem (GameObject obj)
    {
        Items.Add(obj);
    }

    public bool RemoveItem (GameObject obj)
    {
        if (Items.Contains(obj))
        {
            Items.Remove(obj);
            return true;
        }
        else
        {
            return false;
        }
    }
}
