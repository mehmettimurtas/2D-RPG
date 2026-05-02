using UnityEngine;

public class enemyCombat : MonoBehaviour
{   
    public int damage = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
          collision.gameObject.GetComponent<playerHealth>().TakeDamage(damage);
        }
    }

}




