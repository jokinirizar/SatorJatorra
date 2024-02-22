using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
public void loadGame()
    {
        SceneManager.LoadScene("scn_tap_a_topo");
    }
    public void loadLeaderBoard()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

}
