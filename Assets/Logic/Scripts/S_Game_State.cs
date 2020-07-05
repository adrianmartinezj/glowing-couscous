using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(S_Scene_Controller))]
public class S_Game_State : MonoBehaviour
{
    public static S_Game_State Instance;

    public delegate void StateAction(State state);
    /// <summary>
    /// Called before the scene corresponding to the new state is loaded and any values are changed.
    /// New scenes are loaded asynchronously so it is not guaranteed to wait for an operation to conclude.
    /// </summary>
    public static event Action OnBeforeNewState;
    /// <summary>
    /// Called after state is changed but before the new scene is loaded.
    /// </summary>
    public static event StateAction OnNewState;
    /// <summary>
    /// Called when the new scene is loaded.
    /// </summary>
    public static event Action OnAfterNewState;

    public S_Scene_Controller SceneController;
    // Start is called before the first frame update
    public enum State { 
        MainMenu,
        Equipment,
        Battle,
        Rewards
    };
    public State CurrentState { get; private set; }

    public void Awake()
    {
        GameState.Instance = this;
    }

    void Start()
    {
        DontDestroyOnLoad(this);

        SceneController = gameObject.GetComponent<S_Scene_Controller>();

        OnNewState += SceneController.UpdateScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateState(State newState)
    {
        OnBeforeNewState?.Invoke();
        CurrentState = newState;
        OnNewState?.Invoke(newState);
    }
}
