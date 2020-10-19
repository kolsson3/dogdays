using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    void FixedUpdate()
    {
        this.transform.Rotate(0f, 0.25f, 0f, Space.World);
    }
}
