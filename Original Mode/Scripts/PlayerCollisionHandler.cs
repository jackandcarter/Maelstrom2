using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public GameObject[] collisionObjects;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherGameObject = collision.gameObject;
        
        if (IsCollisionObjectValid(otherGameObject))
        {
            PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // You can adjust the damage amount as needed.
            }
        }
    }

    private bool IsCollisionObjectValid(GameObject otherObject)
    {
        foreach (GameObject collisionObject in collisionObjects)
        {
            if (otherObject == collisionObject)
            {
                return true;
            }
        }
        return false;
    }
}
