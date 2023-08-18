using UnityEngine;

public class SaveMeEvent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.IncrementLives();
            Destroy(gameObject);
        }
    }
}
