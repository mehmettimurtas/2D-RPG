using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private Transform player;
    private int facingDirection = -1;
    public Animator anim;
    private EnemyState enemyState;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        changeState(EnemyState.Idle);
    }

    void Update()
    {
        if (enemyState == EnemyState.Chasing)
        {
            Chase();
        }

        else if (enemyState == EnemyState.Attacking)
        {

        }


    }



    void Chase()
    {

        if (player.position.x < transform.position.x && facingDirection == -1 ||
            player.position.x > transform.position.x && facingDirection == 1)
        {
            Flip();
        }


        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player == null)
            {
                player = collision.transform;
            }
            changeState(EnemyState.Chasing);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            rb.linearVelocity = Vector2.zero;
            changeState(EnemyState.Idle);
        }
    }

    void changeState(EnemyState newState)
    {
        enemyState = newState;
        switch (enemyState)
        {
            case EnemyState.Idle:
                anim.SetBool("isChasing", false);
                anim.SetBool("isIdle", true);
                break;
            case EnemyState.Chasing:
                anim.SetBool("isChasing", true);
                anim.SetBool("isIdle", false);
                break;
            case EnemyState.Attacking:
                anim.SetBool("isAttacking", true);
                anim.SetBool("isChasing", false);
                anim.SetBool("isIdle", false);
                break;
        }
    }
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
 
}