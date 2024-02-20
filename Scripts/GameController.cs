using Cinemachine;
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

    public CinemachineBrain brain;
    public CinemachineVirtualCamera endCam;
    public CinemachineVirtualCamera GameCam;
    public Animator FadeOutAnimator;

    private bool frameSkipped = false;

    private bool hasTimeSoundPlayed = false;
    void Start()
    {
        timerText.text = String.Format("{0:0.00}", time);
        Cursor.lockState = CursorLockMode.Locked;
        FadeOutAnimator.gameObject.SetActive(true);
        FadeOutAnimator.SetTrigger("StartFadeIn");
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
        endCam.enabled = false;
        mainAudioController.playMusic(PlaySong);
    }
    private void FinishGame()
    {
        endCam.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        countdownTextScript.ChangeToFinishText();

    }
    private void Update()
    {
        if(frameSkipped){
            GameCam.enabled = true;
        }
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
            brain.m_DefaultBlend.m_Time = 8;
            FadeOutAnimator.SetTrigger("StartFadeOut");
        }

        if (time < 15)
        {
            if(!hasTimeSoundPlayed)
            {
                mainAudioController.playSFX(LastSeconds);
                    hasTimeSoundPlayed = true;              
            }
    
        }
        frameSkipped = true;
    }
}
