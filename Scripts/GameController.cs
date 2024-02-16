using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool isCursorEnabled = false;
    public bool gameStarted = false;

    public ComboPoints combopoints;

    public Animator chronoAnimator;
    public TextMeshProUGUI points;
    public resetTextValues countdownTextScript;

    public MainAudioController mainAudioController;
    public AudioClip LastSeconds;
    public AudioClip PlaySong;

    public delegate void EventHandlerInitialize();

    public static event EventHandlerInitialize OnFinish;

    public TextMeshProUGUI  timerText;
    public float time = 60f;

    private bool hasTimeSoundPlayed = false;
    void Start()
    {
        timerText.text = String.Format("{0:0.00}", time);
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(StartCountdown(5));
    }

    public void addPointsToComboText()
    {
        combopoints.changeComboPoints();
        combopoints.resetComboTimer();
    }

   IEnumerator StartCountdown(int secs)
   {
        yield return new WaitForSeconds(secs);
        Cursor.lockState = CursorLockMode.Confined;
        isCursorEnabled = true;
        gameStarted = true;
        mainAudioController.playMusic(PlaySong);
    }
    private void FinishGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        countdownTextScript.ChangeToFinishText();

    }
    private void Update()
    {
        if (time>0&& gameStarted)
        {
       
            if (chronoAnimator.enabled == false)
            {
                chronoAnimator.enabled = true;
            }
            time -= Time.deltaTime;
            timerText.text= String.Format("{0:0.00}", time);
        }
        else if(gameStarted&&time <= 0)
        {
            Debug.Log("changed");
            FinishGame();
            OnFinish();
            gameStarted = false;
        }

        if (time < 15)
        {
            if(!hasTimeSoundPlayed)
            {
                mainAudioController.playSFX(LastSeconds);
                    hasTimeSoundPlayed = true;              
            }
    
        }
       
    }
}
