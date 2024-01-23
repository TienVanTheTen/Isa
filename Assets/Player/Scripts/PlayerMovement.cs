using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    [SerializeField] 
    private float moveSpeed;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator bodyAnimator;

    private Vector2 movement;
   

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

       
        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        //set animations
        if((movement != Vector2.zero))
        {
            bodyAnimator.SetFloat("MoveX", movement.x);
            bodyAnimator.SetFloat("MoveY", movement.y);
        }
       

        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

    }
    private void UpdateAnimator()
    {
        if(movement != Vector2.zero)
        {
            bodyAnimator.Play("PlayerWalk");
        }
        else
        {
            bodyAnimator.Play("PlayerIdle");
        }
    }
}
