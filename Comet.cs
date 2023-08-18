using UnityEngine;

public class Comet : MonoBehaviour
{
    public float speed = 8f;

    private void Start()
    {
        Destroy(gameObject, 8f);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.IncrementScore(5000);
            Destroy(gameObject);
        }
    }
}
