using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class HighscoreManager : MonoBehaviour
{
    private string highscoreFilePath;
    private List<HighscoreEntry> highscores; 
    public int maxHighscores = 9; 
     
    [System.Serializable]
    public class HighscoreEntry
    {
        public string name;
        public int score;
    }

    void Start()
    {

        highscores = new List<HighscoreEntry>();
        highscoreFilePath = Application.persistentDataPath + "/highscores.json";
        LoadHighscores();
    }


    public void AddHighscore(string name, int score)
    {
        HighscoreEntry newEntry = new HighscoreEntry { name = name, score = score };
        highscores.Add(newEntry);


        highscores.Sort((x, y) => y.score.CompareTo(x.score));


        if (highscores.Count > maxHighscores)
        {
            highscores.RemoveRange(maxHighscores, highscores.Count - maxHighscores);
        }


        SaveHighscores();
    }

    private void SaveHighscores()
    {
        Debug.Log("saving");    
        string json = JsonUtility.ToJson(highscores);
        File.WriteAllText(highscoreFilePath, highscores.ToString());
        Debug.Log(highscoreFilePath);
    }

    private void LoadHighscores()
    {
        if (File.Exists(highscoreFilePath))
        {
            string json = File.ReadAllText(highscoreFilePath);
            highscores = JsonUtility.FromJson<List<HighscoreEntry>>(json);

            highscores.Sort((x, y) => y.score.CompareTo(x.score));
        }
    }
    public List<HighscoreEntry> GetHighscores()
    {
        return highscores;
    }
}