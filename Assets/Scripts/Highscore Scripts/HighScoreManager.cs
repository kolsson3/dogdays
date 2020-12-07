using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Manager class for high score entries and rendering onto high score screen.
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

        //Create highscore list from player prefs info.
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

        //Display all high score entries, or 5, whichever is less.
        highscoreEntryTransformList = new List<Transform>();
        int toDisplay = highscoreEntryList.Count > 5 ? 5 : highscoreEntryList.Count;
        for (int i = 0; i < toDisplay; i++)
        {
            CreateHighscoreEntryTransform(highscoreEntryList[i], entryContainer, highscoreEntryTransformList);
        }
    }

    //Create transform to contain high score entry.
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        //Set up entry container.
        float containerHeight = 45f;
        Transform entryTransform = Instantiate(entryTemp, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -containerHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        //Create rank
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

        //Create score
        int score = highscoreEntry.score;
        entryTransform.Find("Score").GetComponent<Text>().text = score.ToString();

        //Create name
        string name = highscoreEntry.name;
        entryTransform.Find("Name").GetComponent<Text>().text = name;

        //Unique formatting for first place.
        if (rank == 1)
        {
            entryTransform.Find("Name").GetComponent<Text>().color = Color.red;
            entryTransform.Find("Position").GetComponent<Text>().color = Color.red;
            entryTransform.Find("Score").GetComponent<Text>().color = Color.red;
        }
        transformList.Add(entryTransform);
    }

    //Container class for the high score list.
    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }
}

