using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public float timeLimit = 30f;
    private float startTime;

    private Text timerText;

    private void Start()
    {
        timerText = GetComponent<Text>();
        startTime = Time.time;
    }

    private void Update()
    {
        float currentTime = Time.time - startTime;
        float remainingTime = Mathf.Max(0f, timeLimit - currentTime);

        string minutes = Mathf.Floor(remainingTime / 60).ToString("00");
        string seconds = (remainingTime % 60).ToString("00");

        timerText.text = minutes + ":" + seconds;

        if (remainingTime <= 0f)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.CheckForGameover();
            }
        }
    }
}

