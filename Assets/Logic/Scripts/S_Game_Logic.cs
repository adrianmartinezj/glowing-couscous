using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Game_Logic : MonoBehaviour
{
    [System.Serializable]
    public struct PlayerValues
    {
        public GameObject PlayerCharacter;
    }
    public PlayerValues playerValues;
    public GameObject Player { get; private set; }

    private S_SpawnController SpawnController;
    // Start is called before the first frame update
    void Start()
    {
        // Setup current Player
        Player = Instantiate(playerValues.PlayerCharacter);
        Player.transform.position = new Vector3(0, 1, 0);

        SpawnController = gameObject.AddComponent<S_SpawnController>();

        DontDestroyOnLoad(this);
        DontDestroyOnLoad(Player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
