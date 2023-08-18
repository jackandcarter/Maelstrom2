using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public enum AsteroidSize { Large, Medium, Small }
    public AsteroidSize size;
    public int requiredHits = 1;

    public GameObject nextSizeAsteroidPrefab;
    public GameObject explosionPrefab;
    public int pointValue = 0;
    
    private int currentHits = 0;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            currentHits++;
            
            if (currentHits >= requiredHits)
            {
                SplitAsteroid();
                DestroyAsteroid();
            }
        }
    }
    
    private void SplitAsteroid()
    {
        if (nextSizeAsteroidPrefab != null)
        {
            Instantiate(nextSizeAsteroidPrefab, transform.position, transform.rotation);
            Instantiate(nextSizeAsteroidPrefab, transform.position, transform.rotation);
        }
    }
    
    private void DestroyAsteroid()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        GameManager.instance.IncrementScore(pointValue);
        
        Destroy(gameObject);
    }
}
