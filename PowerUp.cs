using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { AmmoUpgrade, ShieldRefill }
    public PowerUpType type;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplyEffect();
            Destroy(gameObject);
        }
    }
    
    private void ApplyEffect()
    {
        switch (type)
        {
            case PowerUpType.AmmoUpgrade:
                // Implement logic for upgrading the player's ammo
                break;
            
            case PowerUpType.ShieldRefill:
                // Implement logic for refilling the player's shield
                break;
            
            // Handle additional power-up types if needed
        }
    }
}
