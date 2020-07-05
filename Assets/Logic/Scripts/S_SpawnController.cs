using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class S_SpawnController : MonoBehaviour
{
    private enum SpawnType { Player, Adversary };
    private Dictionary<SpawnType, GameObject> m_Spawners;

    private const string playerTag = "PlayerSpawner";
    private const string adversaryTag = "AdversarialSpawner";
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Init()
    {
        // Find the spawners in the map
        GameObject pSpawn = GameObject.FindGameObjectWithTag(playerTag);
        GameObject aSpawn = GameObject.FindGameObjectWithTag(adversaryTag);

        Assert.IsNotNull(pSpawn, "Player spawn is null.");
        m_Spawners.Add(SpawnType.Player, pSpawn);
        Assert.IsNotNull(aSpawn, "Adversary spawn is null.");
        m_Spawners.Add(SpawnType.Adversary, aSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
