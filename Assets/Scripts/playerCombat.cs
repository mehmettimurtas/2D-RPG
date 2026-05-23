using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public int attackDamage = 15;
    public LayerMask enemyLayer;
    public float attackRange = 1f;
    public Transform attackPoint;
    public Animator anim;
    public float cooldown = 1.5f;
    private float timer = 0f;

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

    }


    public void playerAttack()
    {
        if (timer <= 0)
        {
            anim.SetBool("isAttacking", true);
            timer = cooldown;
        }
        
    }

    public void finishAttack()
    {
        anim.SetBool("isAttacking", false);
    }

    public void DealDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        if (hitEnemies.Length > 0)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<enemyHealth>().takeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }








}   
 

