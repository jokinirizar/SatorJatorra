using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnimationEnd : MonoBehaviour
{
public RaycastMainMenu controller;

    public void onAnimationEnd()
    {
        controller.onFadeOutFinish();
    }
}
