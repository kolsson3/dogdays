using UnityEngine;

//Script for first person camera control.
public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100f; //Camera sensitivity.
    public Transform PlayerBody; //Player transform.
    public float xRotation = 0f; //x axis rotation

    void Start()
    {
        //Lock cursor at the start of the game.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Get mouse input
        float MouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        //Apply mouse input to x rotation.
        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 84f);

        //Apply rotations.
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * MouseX);
    }
}
