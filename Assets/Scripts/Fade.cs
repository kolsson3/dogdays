using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour
{

    public Animator anim;
    public Image white;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => white.color.a == 1);
        anim.SetBool("Fade", false);
        SceneManager.LoadScene("Menu");
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("Alpha");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
