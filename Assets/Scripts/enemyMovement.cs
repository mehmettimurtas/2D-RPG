using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private bool isChasing;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isChasing == true)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player == null)
            { 
               player = collision.transform; 
            }
            isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isChasing = false;
            rb.linearVelocity = Vector2.zero;
        }
    }
}