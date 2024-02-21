using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEndGameFadeOut : MonoBehaviour
{
    public GameController gameController;
  public void EndGameFadeOut()
    {
        gameController.startHighscoreFadeIn();
    }
}
