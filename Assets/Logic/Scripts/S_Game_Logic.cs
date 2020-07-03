using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Game_Logic : MonoBehaviour
{
    public GameObject Player { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Player = Instantiate(new GameObject("PlayerCharacter"));
        Player.AddComponent<ControllableCharacter>();
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(Player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
