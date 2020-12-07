using UnityEngine;

//Separate score tracker to be transferred to high score entry scene.
public class ScoreTracker : MonoBehaviour
{
    private static ScoreTracker instance; //ScoreTracker instance.
    public int score; //Score being tracked.

    void Awake()
    {
        //Dont destroy the object unless a new one exists.
        //This way it's kept when transferring to name entry scene, but destroyed on a new game.
        DontDestroyOnLoad(this.gameObject);
        if (!instance) instance = this;
        else Destroy(gameObject);
    }
}
