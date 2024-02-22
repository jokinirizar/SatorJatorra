using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool isCursorEnabled = false;
    public bool gameStarted = false;

    public ComboPoints combopoints;

    public Animator chronoAnimator;
    public TextMeshProUGUI points;
    public resetTextValues countdownTextScript;

    public MainAudioController mainAudioController;
    public AudioClip EndSFX;
    public AudioClip LastSeconds;
    public AudioClip PlaySong;
    public AudioClip EndingSong;


    public delegate void EventHandlerInitialize();

    public static event EventHandlerInitialize OnFinish;

    public TextMeshProUGUI  timerText;
    public float time = 60f;

    public CinemachineBrain brain;
    public CinemachineVirtualCamera endCam;
    public CinemachineVirtualCamera GameCam;
    public Animator FadeOutAnimator;
    public Animator FadeOutAnimatorSecondPanel;

    public HighscoreManager highscoreManager;
    public GameObject highscorePanel;
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
    public void OnMainMenuClick()
    {
        FadeOutAnimatorSecondPanel.gameObject.SetActive(true);
        FadeOutAnimatorSecondPanel.SetTrigger("startFadeOutFastEvent");
    }

    public void OnRetryClick()
    {
        FadeOutAnimatorSecondPanel.gameObject.SetActive(true);
        FadeOutAnimatorSecondPanel.SetTrigger("startFadeOutFastEventRetry");
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

    IEnumerator StartFinalSong(float secs)
    {
        yield return new WaitForSeconds(secs);
        mainAudioController.playMusic(EndingSong);
    }
    private void FinishGame()
    {
        endCam.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        countdownTextScript.ChangeToFinishText();
        OnFinish();
        mainAudioController.playSFX(EndSFX);
        StartCoroutine(StartFinalSong(0.5f));
        gameStarted = false;
        brain.m_DefaultBlend.m_Time = 8;
        FadeOutAnimator.gameObject.SetActive(true);
        FadeOutAnimator.SetTrigger("StartFadeOut");


    }
    public void startHighscoreFadeIn()
    {
        //FadeOutAnimator.gameObject.SetActive(false);
        highscorePanel.gameObject.SetActive(true);
        highscorePanel.GetComponent<Animator>().SetTrigger("startFadeInFastEvent");
        highscoreManager.AddHighscore("player", Int32.Parse(points.text));  
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void onHighscoreLoad()
    {
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
            FinishGame();
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
