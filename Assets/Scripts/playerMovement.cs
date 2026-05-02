using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
public class playerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public int facingDirection = 1;
    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
        rb.linearVelocity = movement * speed;
        animator.SetFloat("horizontal", Mathf.Abs(moveHorizontal));
        animator.SetFloat("vertical", Mathf.Abs(moveVertical));

        if (moveHorizontal > 0 && transform.localScale.x < 0 || moveHorizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

    }
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

}
