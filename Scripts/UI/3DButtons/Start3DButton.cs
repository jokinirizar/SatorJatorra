using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start3DButton : Base3DButton
{
    public override void OnClick()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("scn_tap_a_topo");
    }

}
