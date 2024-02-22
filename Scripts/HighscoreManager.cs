using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class HighscoreManager : MonoBehaviour
{
    private string highscoreFilePath;
    private HighscoreClass highscoreClass;
    public int maxHighscores = 9; 
     
    [System.Serializable]
    public class HighscoreEntry
    {
        public string name;
        public int score;
    }

    void Start()
    {

       // highscoreClass = new List<HighscoreEntry>();
        highscoreFilePath = Application.persistentDataPath + "/highscores.json";
        LoadHighscores();
    }


    public void AddHighscore(string name, int score)
    {
        HighscoreEntry newEntry = new HighscoreEntry { name = name, score = score };
        highscoreClass.Highscores.Add(newEntry);


        highscoreClass.Highscores.Sort((x, y) => y.score.CompareTo(x.score));


        if (highscoreClass.Highscores.Count > maxHighscores)
        {
            highscoreClass.Highscores.RemoveRange(maxHighscores, highscoreClass.Highscores.Count - maxHighscores);
        }


        SaveHighscores();
    }

    private void SaveHighscores()
    {
        Debug.Log(highscoreClass.Highscores[0].score);
        string json = JsonUtility.ToJson(highscoreClass);
        Debug.Log(json);
        File.WriteAllText(highscoreFilePath, json);
    }

    private void LoadHighscores()
    {
        if (File.Exists(highscoreFilePath))
        {
            string json = File.ReadAllText(highscoreFilePath);
            highscoreClass = JsonUtility.FromJson<HighscoreClass>(json);
            //Debug.Log(highscores);
            if (highscoreClass.Highscores == null)
            {
                highscoreClass.Highscores = new List<HighscoreEntry>();
            }
            highscoreClass.Highscores.Sort((x, y) => y.score.CompareTo(x.score));
        }
    }
    public List<HighscoreEntry> GetHighscores()
    {
        return highscoreClass.Highscores;
    }
     public class HighscoreClass
    {
        public List<HighscoreEntry> Highscores;
    }
}