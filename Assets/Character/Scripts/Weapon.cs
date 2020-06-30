using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Entity
{
    public Weapon(int id, int damage, float speed, string name)
    {
        this.id = id;
        this.damage = damage;
        this.speed = speed;
        this.name = name;
    }
    public int damage { get; private set; }
    public float speed { get; private set; }
}
