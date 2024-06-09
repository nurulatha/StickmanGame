using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    public float moveSpeed;
    public float jumpForce;

    private enum MovementState { diam, lari, lompat }

    public LayerMask jumpableGround;
    public AudioSource jumpSoundEffect;
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        MovementState state;

        // untuk gerak kanan kiri
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed ,rb.velocity.y);

        // untuk lompat
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // untuk animasi diam ke lari or sebaliknya
        if(dirX > 0f)
        {
            state = MovementState.lari;
            // untuk bisa balik jadi hadap kanan
            sprite.flipX = false;
        }
        else if(dirX < 0f)
        {
            state = MovementState.lari;
            // untuk bisa balik jadi hadap kiri
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.diam;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.lompat;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
