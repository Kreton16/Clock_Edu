using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro; // Підключаємо TextMeshPro

public class ClockGameManager : MonoBehaviour
{
    [Header("--- Налаштування Відео ---")]
    public VideoPlayer videoPlayer;
    public GameObject videoPanel; 

    [Header("--- Налаштування Задачі ---")]
    public Image analogClockDisplay; 
    public List<ClockTask> tasks; 

    [Header("--- Електричний годинник (UI/3D Text) ---")]
    public TextMeshProUGUI hourText;  
    public TextMeshProUGUI minuteText; 
    public TextMeshProUGUI feedbackText; 

    private int currentInputHour = 12;
    private int currentInputMinute = 0;
    private ClockTask currentTask;

    void Start()
    {
        videoPanel.SetActive(false);
        analogClockDisplay.gameObject.SetActive(false);
        feedbackText.text = "";
        UpdateDigitalClockDisplay();
    }

    public void PlayTutorialVideo()
    {
        analogClockDisplay.gameObject.SetActive(false);
        videoPanel.SetActive(true);
        videoPlayer.Play();
    }

    public void CloseVideoAndStartTask()
    {
        videoPlayer.Stop();
        videoPanel.SetActive(false);
        StartRandomTask();
    }

    void StartRandomTask()
    {
        if (tasks.Count == 0) return;

        int randomIndex = Random.Range(0, tasks.Count);
        currentTask = tasks[randomIndex];

        analogClockDisplay.gameObject.SetActive(true);
        analogClockDisplay.sprite = currentTask.clockImage;

        feedbackText.text = "Встанови час на годиннику!";
    }


    public void ChangeHour(int direction)
    {
        currentInputHour += direction;

        if (currentInputHour > 12) currentInputHour = 1;
        if (currentInputHour < 1) currentInputHour = 12;

        UpdateDigitalClockDisplay();
    }

    public void ChangeMinute(int direction) 
    {

        if (direction > 0) currentInputMinute += 15;
        else currentInputMinute -= 15;

        if (currentInputMinute >= 60) currentInputMinute = 0;
        if (currentInputMinute < 0) currentInputMinute = 45;

        UpdateDigitalClockDisplay();
    }

    void UpdateDigitalClockDisplay()
    {
        hourText.text = currentInputHour.ToString("00");
        minuteText.text = currentInputMinute.ToString("00");
    }

    public void CheckAnswer()
    {
        if (currentInputHour == currentTask.correctHour &&
            currentInputMinute == currentTask.correctMinute)
        {
            feedbackText.text = "Вітаю, ти правильно визначив!";
            feedbackText.color = Color.green;
        }
        else
        {
            feedbackText.text = "Спробуй ще раз!";
            feedbackText.color = Color.red;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            PlayTutorialVideo();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            CloseVideoAndStartTask();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            CheckAnswer();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeHour(1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeHour(-1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeMinute(1);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeMinute(-1);
        }
    }
}
