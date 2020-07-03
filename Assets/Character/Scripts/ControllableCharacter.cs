using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static DatabaseSystem;

public class ControllableCharacter : BaseCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        const string path = "items";
        EntityDatabase ed = EntityDatabase.Load(path);
        foreach (Weapon wep in ed.weapons)
        {
            inventory.AddItem(wep);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
