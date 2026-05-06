using UnityEngine;

public class enemyCombat : MonoBehaviour
{   
    public int damage = 5;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask playerLayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
          collision.gameObject.GetComponent<playerHealth>().TakeDamage(damage);
        }
    }

    public void Attack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<playerHealth>().TakeDamage(damage);
        }
    }
}




