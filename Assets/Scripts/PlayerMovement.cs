using UnityEngine;
using UnityEngine.SceneManagement;

//Script hangling player movement and barking.
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; //Character controller component.
    public GoalManager gm; //Goal manager.
    public float speed = 15f; //Player speed.
    private float vSpeed = 0f; //Current vertical speed.
    public float jumpSpeed = 2.5f; //Jump speed.
    float gravity = 9.8f; //Gravity constant.
    bool run = false; //Is player running?

    //Audio clips and source for barking.
    public AudioClip bark1;
    public AudioClip bark2;
    public AudioClip bark3;
    public AudioSource source;

    //Bark count and bark goal triggered bool.
    private int barkCount = 0;
    bool barked = false;

    void Update()
    {
        //A couple input checkers for reseting the game or returning to menu.
        if (Input.GetKeyDown(KeyCode.I)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Input.GetKeyDown(KeyCode.O)) SceneManager.LoadScene("Menu");

        //Bark input.
        if (Input.GetButtonDown("Bark")) Bark();
        //Sprint input.
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Set run to true and enable collider for pushing objects while sprinting.
            //Collider switch is so that players can effectively climb stacked objects.
            run = true;
            this.GetComponent<CapsuleCollider>().enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //Disable run and collider.
            run = false;
            this.GetComponent<CapsuleCollider>().enabled = false;
        }

        //Get player input.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //If running, double speed.
        if (run)
        {
            x *= 2;
            z *= 2;
        }
        
        //Create movement vector from input values.
        Vector3 move = transform.right * x + transform.forward * z;

        //If player is on the ground...
        if (controller.isGrounded)
        {
            //Reset verrtical speed and apply jumpspeed from input.
            vSpeed = 0; 
            if (Input.GetKeyDown("space")) vSpeed = jumpSpeed;
        }

        //Apply gravity acceleration to vertical speed:
        vSpeed -= gravity * Time.deltaTime;
        //Include vertical speed in vel
        move.y = vSpeed; 
        //Apply movement to character controller.
        controller.Move(move * speed * Time.deltaTime);
    }

    //The much requested bark function.
    public void Bark()
    {
        //Three barks available randomly. 1% chance of triggering the third, weird sounding one. The implication being you barked too much and your voice cracked.
        int bark = Random.Range(0, 100);
        if(bark == 0) source.PlayOneShot(bark3, 1.0f);
        else if (bark < 40) source.PlayOneShot(bark2, 1.0f);
        else source.PlayOneShot(bark1, 1.0f);

        //Check/increment bark count. If high enough, trigger goal.
        if (barkCount < 5 && !barked) barkCount++;
        else
        {
            gm.Complete("loud");
            barked = true;
        }
    }
}
