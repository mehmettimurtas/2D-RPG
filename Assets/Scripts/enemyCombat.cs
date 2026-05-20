using UnityEngine;

public class enemyCombat : MonoBehaviour
{   
    public int damage = 5;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask playerLayer;


    public void Attack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        if (hitPlayer.Length > 0)
        {
            hitPlayer[0].GetComponent<playerHealth>().TakeDamage(damage);
        }
        
    }
}




