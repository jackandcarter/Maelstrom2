using UnityEngine;

public class SpaceJunk : MonoBehaviour
{
    public float speed = 10f;
    public int health = 3;
    public GameObject rawMaterialPrefab;
    public GameObject powerUpIconPrefab; // New

    private void Update()
    {
        Vector3 movement = Vector3.left * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            DestroyJunk();
        }
    }

    private void DestroyJunk()
    {
        if (rawMaterialPrefab != null)
        {
            Instantiate(rawMaterialPrefab, transform.position, Quaternion.identity);
        }

        if (powerUpIconPrefab != null) // New
        {
            Instantiate(powerUpIconPrefab, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}
