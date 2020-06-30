using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    // Public
    public List<Entity> Items { get; private set; }

    public Inventory()
    {
        Debug.Log("Constructing inventory");
        Items = new List<Entity>();
    }

    public void AddItem (Entity obj)
    {
        Items.Add(obj);
    }

    public bool RemoveItem (Entity obj)
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
