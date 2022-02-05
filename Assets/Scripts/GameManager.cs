using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName1;
    public string playerName2;
    public string playerName3;
    public int score1;
    public int score2;
    public int score3;
    public string playerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    public void SetScore(string name, int score)
    {
        if (score >= score1)
        {
            score3 = score2;
            score2 = score1;
            score1 = score;
            playerName3 = playerName2;
            playerName2 = playerName1;
            playerName1 = name;
        }
        else if (score >= score2)
        {
            score3 = score2;
            score2 = score;
            playerName3 = playerName2;
            playerName2 = name;
        }
        else if (score >= score3)
        {
            score3 = score;
            playerName3 = name;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName1;
        public string playerName2;
        public string playerName3;
        public int score1;
        public int score2;
        public int score3;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.playerName1 = playerName1;
        data.playerName2 = playerName2;
        data.playerName3 = playerName3;
        data.score1 = score1;
        data.score2 = score2;
        data.score3 = score3;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName1 = data.playerName1;
            playerName2 = data.playerName2;
            playerName3 = data.playerName3;
            score1 = data.score1;
            score2 = data.score2;
            score3 = data.score3;
        }
    }
}
