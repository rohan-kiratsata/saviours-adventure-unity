using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rigibBody;
    private BoxCollider2D collidePlayer;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private AudioSource jumpSound;
    // [SerializeField] private AudioSource eatSound;
    // [SerializeField] private AudioSource dieSound;
    // [SerializeField] private AudioSource levelCompleteSound;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float dirX = 0f, playerSpeed = 7f, playerJumpForce = 14f;
    private enum MovementState
    {
        idle, running, jumping, falling
    }
    private MovementState state = MovementState.idle;
    
    
    
    private void Start()
    {
        rigibBody = GetComponent<Rigidbody2D>();
        collidePlayer = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    private void Update() 
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rigibBody.velocity = new Vector2(dirX * playerSpeed, rigibBody.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigibBody.velocity = new Vector2(0, playerJumpForce);

            // Jump Sound
            jumpSound.Play();

        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false; 
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rigibBody.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rigibBody.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collidePlayer.bounds.center, collidePlayer.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
