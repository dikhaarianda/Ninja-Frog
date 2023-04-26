using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [Header("For Petrolling")]
    [SerializeField] float moveSpeed;
    private float moveDirection = 1;
    private bool facingRight = true;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] float circleRadius;

    [Header("For JumpAttacking")]
    [SerializeField] float jumpHeight;
    [SerializeField] Transform player;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector2 boxSize;
    private bool isGrounded;

    [Header("For SeeingPlayer")]
    [SerializeField] Vector2 lineOfSite;
    [SerializeField] LayerMask playerLayer;

    [Header("For JumpAttacking")]
    private Rigidbody2D enemyRB;
    private Animator enemyAnim;
    private bool checkingGround;
    private bool checkingWall;
    private bool canSeePlayer;

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        checkingWall = Physics2D.OverlapCircle(wallCheckPoint.position, circleRadius, wallLayer);
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
        canSeePlayer = Physics2D.OverlapBox(transform.position, lineOfSite, 0, playerLayer);
        AnimationController();

        if (!canSeePlayer && isGrounded)
        {
            Petrolling();
        }
    }

    private void Petrolling()
    {
        if (checkingWall)
        {
            if (facingRight)
            {
                Flip();
            }
            else if (!facingRight)
            {
                Flip();
            }
        }
        enemyRB.velocity = new Vector2(moveSpeed * moveDirection, enemyRB.velocity.y);
    }

    private void JumpAttack()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;

        if (isGrounded)
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer*3, jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void FlipTowardsPlayer()
    {
        float playerPosition = player.position.x - transform.position.x;
        if (playerPosition>0 && facingRight)
        {
            Flip();
        }
        else if (playerPosition<0 && !facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        moveDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    void AnimationController()
    {
        enemyAnim.SetBool("canSeePlayer", canSeePlayer);
        enemyAnim.SetBool("isGround", isGrounded);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundCheck.position, boxSize);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, lineOfSite);
    }
}
