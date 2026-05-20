using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public Animator anim;


    public void playerAttack()
    {
        anim.SetBool("isAttacking", true);
    }

    public void finishAttack()
    {
        anim.SetBool("isAttacking", false);
    }



}   


