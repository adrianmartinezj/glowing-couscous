using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_EquipmentMenu : MonoBehaviour
{
    private const float TIMER_LENGTH = 0;
    private bool InCountdown = false;
    private float timeLeft = TIMER_LENGTH;
    private Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        
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
                LoadScene();
            }
        }
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

    private void LoadScene()
    {
        SceneManager.LoadScene("TestScene");
    }
}
