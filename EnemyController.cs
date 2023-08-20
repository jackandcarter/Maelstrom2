using UnityEngine;

public class EnemyController : MonoBehaviour, IScreenWrappable
{
    public int wavePoints = 1000;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            DestroyEnemy();
            GameManager.instance.IncreaseScore(wavePoints);
        }
    }

    void DestroyEnemy()
    {
        // Play destruction animation or sound
        Destroy(gameObject);
    }

    public void WrapAroundScreen()
    {
        // Get the enemy's current position
        Vector3 currentPosition = transform.position;

        // Check if the enemy is off-screen to the right
        if (currentPosition.x > ScreenUtils.ScreenRight)
        {
            // Reposition the enemy to the left side of the screen
            currentPosition.x = ScreenUtils.ScreenLeft;
        }
        // Check if the enemy is off-screen to the left
        else if (currentPosition.x < ScreenUtils.ScreenLeft)
        {
            // Reposition the enemy to the right side of the screen
            currentPosition.x = ScreenUtils.ScreenRight;
        }

        // Check if the enemy is off-screen above
        if (currentPosition.y > ScreenUtils.ScreenTop)
        {
            // Reposition the enemy to the bottom of the screen
            currentPosition.y = ScreenUtils.ScreenBottom;
        }
        // Check if the enemy is off-screen below
        else if (currentPosition.y < ScreenUtils.ScreenBottom)
        {
            // Reposition the enemy to the top of the screen
            currentPosition.y = ScreenUtils.ScreenTop;
        }

        // Update the enemy's position
        transform.position = currentPosition;
    }
}
