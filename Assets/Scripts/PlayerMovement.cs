using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed = 200;
    [SerializeField] private float jumpForce;
    [Header("Feet")]
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private float raycastDistance;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private AudioClip[] jumpSFXs;
    [SerializeField] private ParticleSystem jumpParticleSystem;
    private AudioSource audioSource;
    private Rigidbody2D rgbd;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float moveDirection;
    private bool canMove = true;


        // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        // static private void Init()
        // {
        //     InputSystem.actions.Enable();
        // }

    public void GetMove(InputAction.CallbackContext callbackContext){
        moveDirection = callbackContext.ReadValue<float>();
    }

    public void GetJump(InputAction.CallbackContext callbackContext){
Jump(callbackContext);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("MoveSpeed", Mathf.Abs(rgbd.linearVelocity.x));
        animator.SetFloat("VerticalSpeed", rgbd.linearVelocity.y);
        animator.SetBool("IsGrounded", IsGrounded());

        if (moveDirection < 0f)
        {
            FlipSprite(true);
        }
        if (moveDirection > 0f)
        {
            FlipSprite(false);
        }
    }

    void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }
        rgbd.linearVelocity = new Vector2(moveDirection * moveSpeed * Time.deltaTime, rgbd.linearVelocity.y);
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
            jumpParticleSystem.Play();
            int randomSFX = Random.Range(0, jumpSFXs.Length);
            audioSource.PlayOneShot(jumpSFXs[randomSFX]);
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
