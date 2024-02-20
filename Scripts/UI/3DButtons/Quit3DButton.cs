using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit3DButton : Base3DButton
{
    public override void OnClick()
    {
        Debug.Log("Quit");
       Application.Quit();
    }


}
