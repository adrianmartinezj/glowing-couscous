using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class BaseCharacter : MonoBehaviour
{
    [SerializeField]
    protected Mesh CharacterMesh;

    protected Rigidbody m_RigidBody;
    protected MeshFilter m_MeshFilter;
    protected MeshRenderer m_MeshRenderer;

    protected readonly Inventory m_Inventory = new Inventory();

    protected virtual void Start()
    {
        // Find our required components
        m_RigidBody = GetComponent<Rigidbody>();
        m_MeshFilter = GetComponent<MeshFilter>();
        m_MeshRenderer = GetComponent<MeshRenderer>();

    }
    public Inventory inventory { get { return m_Inventory; } }
}
