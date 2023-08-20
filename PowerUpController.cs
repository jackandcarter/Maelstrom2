using UnityEngine;

public class PowerUpController : MonoBehaviour, IScreenWrappable
{
    public float duration = 10f; // Set the duration of the power-up effect
    public GameObject[] powerUpEffects; // Set the power-up effects prefabs

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ApplyPowerUpEffect(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void ApplyPowerUpEffect(GameObject player)
    {
        // Handle power-up effect application logic
    }
}
