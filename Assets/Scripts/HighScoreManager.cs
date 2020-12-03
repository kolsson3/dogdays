using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemp;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemp = entryContainer.Find("HighscoreEntry");

        entryTemp.gameObject.SetActive(false);

        // Add test entry
        //AddHighscoreEntry(23232, "DFD");


        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        highscoreEntryList = highscores.highscoreEntryList;

        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        // Reset the highsores table to empty
        /*
        highscoreEntryList = new List<HighscoreEntry>(); 
        string json = JsonUtility.ToJson(highscoreEntryList);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
        */

    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float containerHeight = 40f;
        Transform entryTransform = Instantiate(entryTemp, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -containerHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("Position").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("Score").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;

        entryTransform.Find("Name").GetComponent<Text>().text = name;

        if (rank == 1)
        {
            entryTransform.Find("Name").GetComponent<Text>().color = Color.red;
            entryTransform.Find("Position").GetComponent<Text>().color = Color.red;
            entryTransform.Find("Score").GetComponent<Text>().color = Color.red;
        }

        transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name.Trim()};

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);


        int index = highscores.highscoreEntryList.FindIndex(player => player.name == name.Trim());
        if (index >= 0)
        {
            highscores.highscoreEntryList[index].score = score;
        }
        else
        {
            highscores.highscoreEntryList.Add(highscoreEntry);
        }
        

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

}

