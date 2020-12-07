//Class representing a single high score entry.
[System.Serializable]
public class HighscoreEntry
{
    public int score;
    public string name;

    public HighscoreEntry(int score, string name)
    {
        this.score = score;
        this.name = name;
    }
}
