using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] private Transform groundCheck;
  [SerializeField] private LayerMask groundLayer;
  [SerializeField] private float speed;
  [SerializeField] private float jumpingPower;

  [Header("Sound")]
  [SerializeField] private AudioSource effectJump;
  [SerializeField] private AudioSource effectRun;

  private Rigidbody2D rb;
  private SpriteRenderer sprite;
  private Animator anim;

  private float dirX;
  private bool doubleJump;
  private bool isFacingRight;

  private enum MovementState { idle, run, wall, hit, fall, jump, secondJump }

  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    sprite = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
  }

  private void Update()
  {
    dirX = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

    if (dirX > 0 && isFacingRight)
    {
      transform.eulerAngles = Vector2.zero;
      isFacingRight = false;
    }
    else if (dirX < 0 && !isFacingRight)
    {
      transform.eulerAngles = Vector2.up * 180;
      isFacingRight = true;
    }

    jump();
    Animation();
  }

  private void jump()
  {
    if (IsGrounded() && !Input.GetButton("Jump"))
    {
      doubleJump = false;
    }

    if (Input.GetButtonDown("Jump"))
    {
      if (IsGrounded() || doubleJump)
      {
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        doubleJump = !doubleJump;
      }
    }

    if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
    {
      rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
    }
  }

  private void Animation()
  {
    if (rb.velocity.x != 0f && IsGrounded())
    {
      State(MovementState.run);
      effectRun.Play();
    }
    else
    {
      State(MovementState.idle);
    }

    if (rb.velocity.y > .1f && !IsGrounded())
    {
      if(!doubleJump)
      {
        State(MovementState.secondJump);
      }
      else
      {
        State(MovementState.jump);
      }
      effectJump.Play();
    }
    else if (rb.velocity.y < -.1f)
    {
      State(MovementState.fall);
    }
  }

  private void State(MovementState AnimState)
  {
    MovementState state = 0;
    state = AnimState;
    anim.SetInteger("state", (int)state);
  }

  private bool IsGrounded()
  {
    return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
  }
}