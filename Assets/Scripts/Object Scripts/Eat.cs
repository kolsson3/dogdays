using UnityEngine;

//Script that handles eating food.
public class Eat : MonoBehaviour
{
    //Audio objects.
    public AudioSource eatSound;
    public AudioClip eat;

    void OnMouseDown()
    {
        //Eats the food on mouse click, plays sound, and destroys the object.
        if (gameObject.tag == "Food") eatSound.PlayOneShot(eat, 1.0f);
        Destroy(gameObject);
    }
}
