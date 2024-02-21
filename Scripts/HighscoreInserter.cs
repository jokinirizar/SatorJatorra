using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static HighscoreManager;

public class HighscoreInserter : MonoBehaviour
{

    public HighscoreManager HighscoreManager;
    int CurrentIteration = 0;
    void Start()
    {
        List<HighscoreEntry> highscores = HighscoreManager.GetHighscores();

        foreach (HighscoreEntry entry in highscores)
        {
            Debug.Log(CurrentIteration);
            transform.GetChild(CurrentIteration).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text= highscores[0].score.ToString();
            CurrentIteration++;
        }
    }


}
