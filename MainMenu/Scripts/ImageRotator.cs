using UnityEngine;

public class GameObjectRotator : MonoBehaviour
{
    public float rotationSpeed = -90f; // Speed of rotation in degrees per second

    void Update()
    {
        RotateClockwise();
    }

    void RotateClockwise()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
