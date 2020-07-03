using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    protected readonly Inventory m_Inventory = new Inventory();
    public Inventory inventory { get { return m_Inventory; } }
}
