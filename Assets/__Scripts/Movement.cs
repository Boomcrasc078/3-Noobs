using System;
using System.Threading;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed = 200;
    [SerializeField] private float jumpForce;
    [Header("Feet")]
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private float raycastDistance;
    [SerializeField] private LayerMask groundLayerMask;
    private AudioSource audioSource;
    private Rigidbody2D rgbd;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool canMove = true;
    private float moveInput;


    /*     [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static private void Init()
        {
            InputSystem.actions.Enable();
        } */

    public void GetMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<float>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveInput < 0f)
        {
            FlipSprite(true);
        }
        if (moveInput > 0f)
        {
            FlipSprite(false);
        }
    }

    void FixedUpdate()
    {
        // if (!canMove)
        // {
        //     return;
        // }
        rgbd.linearVelocity = new Vector2(moveInput * moveSpeed * Time.deltaTime, rgbd.linearVelocity.y);
    }

    private void FlipSprite(bool direction)
    {
        spriteRenderer.flipX = direction;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            rgbd.AddForce(new Vector2(0, jumpForce));
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(leftFoot.position, Vector2.down, raycastDistance, groundLayerMask);
        RaycastHit2D rightHit = Physics2D.Raycast(rightFoot.position, Vector2.down, raycastDistance, groundLayerMask);

        if (leftHit.collider != null && leftHit)
        {
            return true;
        }

        if (rightHit.collider != null && rightHit)
        {
            return true;
        }

        return false;

    }

    private void OnDisable()
    {
    }

    public void TakeKnockback(float knockbackForce, float upwardsForce)
    {
        canMove = false;
        rgbd.AddForce(new Vector2(knockbackForce, upwardsForce));
        Invoke(nameof(CanMoveAgain), 0.25f);
    }

    private void CanMoveAgain()
    {
        canMove = true;
    }

}
