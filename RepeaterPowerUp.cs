using UnityEngine;
using System.Collections;

public class RepeaterPowerUp : MonoBehaviour
{
    public float duration = 10f; // Duration of the power-up

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                // Apply the repeater power-up
                player.ActivateRepeaterPowerUp();
                
                // Schedule deactivation of the power-up
                StartCoroutine(DeactivatePowerUp(player));

                // Destroy the power-up object
                Destroy(gameObject);
            }
        }
    }

    IEnumerator DeactivatePowerUp(PlayerController player)
    {
        yield return new WaitForSeconds(duration);
        player.DeactivateRepeaterPowerUp();
    }
}
