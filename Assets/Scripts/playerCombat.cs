using UnityEngine;

public class playerCombat : MonoBehaviour
{
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



}   


