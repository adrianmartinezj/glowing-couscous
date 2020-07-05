using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static S_Game_State;

public class S_Scene_Controller : MonoBehaviour
{
    [Serializable]
    public struct StateInfo
    {
        public State State;
        public string Scene;
    }

    [SerializeField]
    public List<StateInfo> StateInfoList;

    public delegate void SceneAction(AsyncOperation loadOper);

    public delegate void StateInfoAction(StateInfo si);

    public event SceneAction OnSceneLoad;

    public event SceneAction OnSceneLoading;

    public event StateInfoAction OnSceneLoaded;

    public StateInfo CurrentStateInfo;

    private AsyncOperation loadingOperation;

    public void UpdateScene(State state)
    {
        foreach(StateInfo sI in StateInfoList)
        {
            if (sI.State == state)
            {
                Debug.Log("Whaddup");

                CurrentStateInfo = sI;
                loadingOperation = SceneManager.LoadSceneAsync("TestScene");
                loadingOperation.completed += LoadingComplete;
                OnSceneLoad?.Invoke(loadingOperation);
                break;
            }
        }
    }

    private void LoadingComplete(AsyncOperation obj)
    {
        OnSceneLoaded?.Invoke(CurrentStateInfo);
        loadingOperation = null;
    }

    private void Update()
    {
        if (loadingOperation != null)
        {
            OnSceneLoading(loadingOperation);
        }
    }
}
