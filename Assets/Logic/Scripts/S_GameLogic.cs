using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GameLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = Instantiate(Player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
