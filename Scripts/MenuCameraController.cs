using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraController : MonoBehaviour
{
    public CinemachineBrain brain;
    public GameObject start, transition, final;
    bool skipFrame =false,skipFrame2=false;
    void Start()
    {
        transition.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!brain.IsBlending && skipFrame2)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        if (!brain.IsBlending&&skipFrame)
        {
            transition.SetActive(false);
            final.SetActive(true);
            skipFrame2 = true;
        }
        skipFrame = true;


    }
}
