using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static S_Game_State;

public class S_EquipmentMenu : MonoBehaviour
{
    private const float TIMER_LENGTH = 0;
    private bool InCountdown = false;
    private float timeLeft = TIMER_LENGTH;
    private Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        GameState.Instance.SceneController.OnSceneLoading += OnSceneLoading; 
    }

    private void OnSceneLoading(AsyncOperation loadOper)
    {
        float progressValue = Mathf.Clamp01(loadOper.progress / 0.9f);
        Debug.Log("Progress Value: " + (Mathf.Round(progressValue * 100) + "%"));
    }

    // Update is called once per frame
    void Update()
    {
        if (InCountdown)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = (Mathf.CeilToInt(timeLeft)).ToString();
            if (timeLeft <= 0)
            {
                InCountdown = false;
                timeLeft = TIMER_LENGTH;
                GameState.Instance.UpdateState(State.Battle);
            }
        }
        //if (loadingOperation != null)
        //{
        //    float progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        //    Debug.Log("Progress Value: " + (Mathf.Round(progressValue * 100) + "%"));
        //    //percentLoaded.text = Mathf.Round(progressValue * 100) + "%";
        //}
    }

    public void HandleReadyClick()
    {
        InCountdown = true;
        GameObject notifPanel = GameObject.Find("NotificationPanel");
        timerText = notifPanel.gameObject.transform.GetChild(0).GetComponent<Text>();
    }

    public void HandleCancelClick()
    {
        InCountdown = false;
        timeLeft = TIMER_LENGTH;
    }
}
