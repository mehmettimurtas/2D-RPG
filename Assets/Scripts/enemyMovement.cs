using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    
    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;
    private int facingDirection = -1;
    private EnemyState enemyState;
    private float attackCooldownTimer;

    
    public float attackRange; 
    public float attackCooldown;
    public float speed;
    public float playerDetectionRange;
    public Transform detectionPoint;
    public LayerMask playerLayer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        changeState(EnemyState.Idle);
    }

    void Update()
    {
        CheckForPlayer();

        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }
        
        if (enemyState == EnemyState.Chasing)
        {
            Chase();
        }
        else if (enemyState == EnemyState.Attacking)
        {
            rb.linearVelocity = Vector2.zero;
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


    private void CheckForPlayer()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectionRange, playerLayer);
        if (hitPlayer.Length > 0)
        {
            player = hitPlayer[0].transform;
            if (Vector2.Distance(transform.position, player.position) <= attackRange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;
                changeState(EnemyState.Attacking);
                
            }
            else if (Vector2.Distance(transform.position, player.position) > attackRange)
            {
                changeState(EnemyState.Chasing);
                
            }
        }
        else
        {
            changeState(EnemyState.Idle);
            rb.linearVelocity = Vector2.zero;

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
                anim.SetBool("isAttacking", false);
                break;
            case EnemyState.Chasing:
                anim.SetBool("isChasing", true);
                anim.SetBool("isIdle", false);
                anim.SetBool("isAttacking", false);
                break;
            case EnemyState.Attacking:
                anim.SetBool("isAttacking", true);
                anim.SetBool("isChasing", false);
                anim.SetBool("isIdle", false);
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (detectionPoint == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectionRange);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}   

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
 
}