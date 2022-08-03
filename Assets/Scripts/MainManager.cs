using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public bool isNotStartApp = false;
    public string currentPlayerName;
    public int currentScore;
    public string savePlayer;
    public int saveScore;

    private void Awake()
    {
        if (instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;

        public void SetData(string newPlayerName, int newScore)
        {
            playerName = newPlayerName;
            score = newScore;
        }
    }

    public void SaveCurrentData()
    {
        Debug.Log("start savedata");
        SaveData data = new SaveData();
        if (currentScore > saveScore)
        {
            data.SetData(currentPlayerName, currentScore);
            Debug.Log("in savedata, data :" + data);
        }
        else
        {
            data.SetData(savePlayer, saveScore);
        }
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);
            savePlayer = data.playerName;
            saveScore = data.score;
            Debug.Log("data :" + data.score + data.playerName);
        }
        else
        {
            savePlayer = "No high score for the moment";
            saveScore = 0;
        }
    }
}