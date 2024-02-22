using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaderboard3DButton : Base3DButton
{
    public override void OnClick()
    {
        SceneManager.LoadScene("LeaderBoard");
    }
}
