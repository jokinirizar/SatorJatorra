using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class MoleScript : MonoBehaviour
{

    public Animator animator;
    public AudioSource audioSource;
    public AudioClip moleHitClip;
    public AudioClip moleAppearClip;

    Coroutine currentShowCoroutine;
    Coroutine currentHideCoroutine;

    public BoxCollider moleCollider;

    GameController gameController;

    public bool gameIsRunning = true;

    private void Start()
    {
        gameController = FindAnyObjectByType<GameController>();
        GameController.OnFinish += DoLastCycle;
    }

    private void DoLastCycle()
    {
        gameIsRunning = false;
        StopAllCoroutines();
        animator.SetTrigger("onGameEnd");
        StartCoroutine(FinalShow(2));
       
    }

    IEnumerator FinalShow(int secs)
    {
        yield return new WaitForSeconds(secs);
        animator.ResetTrigger("onMoleHide");
        animator.ResetTrigger("onWaitTimeFinished");
        animator.ResetTrigger("onGameEnd");
        animator.SetTrigger("onWaitTimeFinished");
       
    }

    public void onMoleHit()
    {
        audioSource.PlayOneShot(moleHitClip);
        moleCollider.enabled = false;
        animator.SetTrigger("onMoleHide");
        if(currentShowCoroutine != null)
        {
            StopCoroutine(currentShowCoroutine);
        }
        gameController.addPointsToComboText();

    }

    public void OnMoleHideAnimationFinished(MoleController parent)
    {
        if(gameIsRunning) {
            currentHideCoroutine = StartCoroutine(MoleIsHiding(5, parent));
        }
      
    }
    public void OnMoleShowAnimationFinished(MoleController parent)
    {
        if(gameIsRunning)
        {
            currentShowCoroutine = StartCoroutine(MoleIsShowing(2, parent));
        }
       
    }

    IEnumerator MoleIsShowing(int secs, MoleController parent)
    {
        yield return new WaitForSeconds(secs);
        parent.transform.GetComponent<Animator>().SetTrigger("onMoleHide");
    }

    IEnumerator MoleIsHiding(int secs,MoleController parent)
    {
        yield return new WaitForSeconds(secs);
        int randomNumber= Random.Range(0,2);
        if(randomNumber == 0)
        {
            animator.SetTrigger("onWaitTimeFinished");
            audioSource.PlayOneShot(moleAppearClip);
        }
        else
        {
            StartCoroutine(MoleIsHiding(5, parent));
        }
       
    }
}
