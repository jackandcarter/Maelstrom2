using UnityEngine;
using System.Collections;

public class SpreaderPowerUp : MonoBehaviour
{
    public float duration = 10f; // Duration of the power-up

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                // Apply the spreader power-up
                player.ActivateSpreaderPowerUp(4); // Fire 4 bullets

                // Destroy the power-up object
                Destroy(gameObject);
            }
        }
    }
}
