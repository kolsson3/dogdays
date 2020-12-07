using UnityEngine;

//Controller for maintaining music between scenes.
public class MusicController : MonoBehaviour
{
    private static MusicController instance; //Static instance of controller.
    private string trackTitle; //Title of audio clip.

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        trackTitle = GetComponent<AudioSource>().clip.name;
        //If no instance, assign this to it.
        if (!instance) instance = this;
        //If track title matches live instance, destroy this one to maintain track.
        else if (instance.trackTitle == trackTitle) Destroy(gameObject);
        //If track title does not match, destroy old instance and reassign to start new track.
        else
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }
}
