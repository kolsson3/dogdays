using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class HighScoreManager : MonoBehaviour
{
    //public GameObject scoreObj;
    public int score = 0; 
    public ScoreManager scMng;
    public string name = "";
    public int highscore = 0;
    const string fileName = "/highscore.dat";

    public static HighScoreManager sCtrl;

    public void Awake()
    {
        if (sCtrl == null)
        {
            DontDestroyOnLoad(gameObject);
            sCtrl = this;
            LoadScore();
        }
    }

    void Start()
    {
        score = scMng.score;
    }

    public void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + fileName, FileMode.Open, FileAccess.Read);
            GameData data = (GameData)bf.Deserialize(fs);
            fs.Close();
            sCtrl.highscore = data.score;
        }
    }

    public void SaveScore()
    {
        if (score > sCtrl.highscore)
        {
            sCtrl.highscore = score;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + fileName, FileMode.OpenOrCreate);
            GameData data = new GameData();
            data.score = score;
            bf.Serialize(fs, data);
            fs.Close();
        }
    }

    public int GetCurrentScore()
    {
        return PlayerPrefs.GetInt("CurrentScore");
    }

    public void SetCurrentScore(int num)
    {
        PlayerPrefs.SetInt("CurrentScore", num);
    }
}

[Serializable]
class GameData
{
    public string name;
    public int score;
}