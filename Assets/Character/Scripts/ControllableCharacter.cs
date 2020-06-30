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
        IDataReader reader = (IDataReader)Command(SQLiteCommand.Select, "* FROM Weapons").Packet;
        while (reader.Read())
        {
            int id = Convert.ToInt32(reader[0].ToString());
            int damage = Convert.ToInt32(reader[1].ToString());
            float speed = float.Parse(reader[2].ToString());
            string name = reader[3].ToString();
            m_Inventory.AddItem(new Weapon(id, damage, speed, name));
        }

        Debug.Log("Inventory: ");
        foreach ( var item in m_Inventory.Items )
        {
            if (item.GetType() == typeof(Weapon))
            {
                Weapon wep = (Weapon)item;
                Debug.Log(" Weapon:");
                Debug.Log("     name: " + wep.name);
                Debug.Log("     damage: " + wep.damage);
                Debug.Log("     speed: " + wep.speed);
                Debug.Log("     id: " + wep.id);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
