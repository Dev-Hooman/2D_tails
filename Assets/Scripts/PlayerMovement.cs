using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private float dirX = 0f;


    
    /*[SerializeField] this keyword is used for
     a variable to have access
     for in UNITY UI COMPONENT*/
    
    /*
     we can also use public to make it visible in 
    Unity UI but with this other script can 
    access the variable
     */

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private AudioSource jumpSoundEffect;

    private enum MovementState { idle, running, jumping, falling};

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
         dirX = Input.GetAxisRaw("Horizontal");
       // Debug.Log(dirX);

        //joystick support x->axis y-axis
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        /*
        we can use direct floating numbers to define axis,
        thus we dont want to reset current axis, thats why we using 
        regibid body current velocity of respective x and y axis
        */
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;

            //anim.SetBool("running", true);
            //this was when we were using only one variable which is running

            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            //anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;

            // anim.SetBool("running", false);

        }
        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;

        }else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;

        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        //confusion accuring here
        //but it will return our BOXCAST that will prevent to jump ifinite
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


}
