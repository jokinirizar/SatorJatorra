using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{

    public Animator animator;   

public void Onclick() {
        Debug.Log("test");
        animator.gameObject.SetActive(true);
    }
    public void OnAnimationEnd()
    {
        SceneManager.LoadScene("main_menu");
    }
}
