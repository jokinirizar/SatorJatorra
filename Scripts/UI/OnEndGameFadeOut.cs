using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEndGameFadeOut : MonoBehaviour
{
    public GameController gameController;
  public void EndGameFadeOut()
    {
        gameController.startHighscoreFadeIn();
       // gameObject.SetActive(false);
    }
    public void HighscoreScreenLoad()
    {
        gameController.onHighscoreLoad();
    }
    public void MainMenuFadeOut()
    {
        SceneManager.LoadScene("main_menu");
    }
    public void RetryFadeOut()
    {
        SceneManager.LoadScene("scn_tap_a_topo");
    }
}
