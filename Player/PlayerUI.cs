using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text livesText;
    public Image repeaterIcon;
    public Image spreaderIcon;
    public Image homingMissileIcon;
    public Image longRangeIcon;
    public Image spaceJunkIcon;

    private PlayerHealth playerHealth;
    private PlayerAmmo playerAmmo;

    private void Start()
    {
        // Get references to the PlayerHealth and PlayerAmmo scripts.
        playerHealth = GetComponent<PlayerHealth>();
        playerAmmo = GetComponent<PlayerAmmo>();
    }

    private void Update()
    {
        // Update player lives text.
        if (livesText != null)
        {
            livesText.text = "Lives: " + playerHealth.GetCurrentLives().ToString();
        }

        // Update power-up icons based on collected power-ups.
        UpdatePowerUpIcons();
    }

    private void UpdatePowerUpIcons()
    {
        // Update power-up icons based on collected power-ups.
        UpdatePowerUpIcon(repeaterIcon, playerAmmo.currentBulletType == BulletTypes.BulletType.Repeater);
        UpdatePowerUpIcon(spreaderIcon, playerAmmo.currentBulletType == BulletTypes.BulletType.Spreader);
        UpdatePowerUpIcon(homingMissileIcon, playerAmmo.currentBulletType == BulletTypes.BulletType.HomingMissile);
        UpdatePowerUpIcon(longRangeIcon, playerAmmo.currentBulletType == BulletTypes.BulletType.LongRange);
        UpdatePowerUpIcon(spaceJunkIcon, false); // Add logic to check if SpaceJunk is collected.
    }

    private void UpdatePowerUpIcon(Image iconImage, bool isActive)
    {
        if (iconImage != null)
        {
            iconImage.gameObject.SetActive(isActive);
        }
    }
}
