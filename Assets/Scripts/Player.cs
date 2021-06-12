
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float       moveSpeed = 20.0f;
    [SerializeField]
    private float       jumpSpeed = 100.0f;
    [SerializeField]
    private float       maxJumpTime = 0.1f;
    [SerializeField]
    private int         maxJumps = 1;
    [SerializeField]
    private int         jumpGravityStart = 1;
    [SerializeField]
    Collider2D          groundCollider;
    [SerializeField]
    Collider2D          airCollider;
    [SerializeField]
    private Transform   groundCheckObject;
    [SerializeField]
    private float       groundCheckRadius = 3.0f; 
    [SerializeField]
    private LayerMask   groundCheckLayer;
    [SerializeField]
    private float       useRadius = 50;
    [SerializeField]
    private LayerMask   useLayer;
    [SerializeField]
    private float knockbackDuration = 0.25f;
    [SerializeField]
    public float knockbackDistance = 50.0f;
    [SerializeField]
    private GameObject waterParticles;

    private float           hAxis;
    private Rigidbody2D     rb;
    private SpriteRenderer  SpriteRenderer; 
    private Animator        animator;
    private int             nJumps;
    private float           timeOfJump;
    private int             currentScore = 0;
    private float           knockbackTimer;

    public int score => currentScore;
    public bool CanFinishLevel { get; set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        CanFinishLevel = false;
    }

    void FixedUpdate()
    {
        if (knockbackTimer <= 0)
        {
            rb.velocity = new Vector2(hAxis * moveSpeed, rb.velocity.y);
        }
    }

   
    private void Update()
    {
        hAxis = Input.GetAxis("Horizontal");

        Collider2D collider = Physics2D.OverlapCircle(groundCheckObject.position, groundCheckRadius, groundCheckLayer);

        bool isGround = (collider != null);

        if (isGround)
        {
            if (collider.tag == "Water")
            {
                waterParticles.SetActive(true);
            }
            else
            {
                waterParticles.SetActive(false);
            }
        }
        
        if ((isGround) && (Mathf.Abs(rb.velocity.y) < 0.1f))
        {
            nJumps = maxJumps;
        }

        Vector2 currentVelocity = rb.velocity;

        if ((Input.GetButtonDown("Jump")) && (nJumps > 0))
        {
            currentVelocity.y = jumpSpeed;

            rb.velocity = currentVelocity;

            nJumps--;

            rb.gravityScale = jumpGravityStart;

            timeOfJump = Time.time;
        }
        else 
        {
            float elapsedTimeSinceJump = Time.time - timeOfJump;
            if ((Input.GetButton("Jump")) && (elapsedTimeSinceJump < maxJumpTime))
            {
                rb.gravityScale = jumpGravityStart;
            }
            else
            {
                rb.gravityScale = 3.5f;
            }
        }

        if (currentVelocity.x < -0.1)
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            currentRotation.y = 180;
            transform.rotation = Quaternion.Euler(currentRotation);
        }
        else if (currentVelocity.x > 0.1)
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            currentRotation.y = 0;
            transform.rotation = Quaternion.Euler(currentRotation);
        }

        animator.SetFloat("absSpeedX", Mathf.Abs(currentVelocity.x));
        animator.SetFloat("SpeedY",currentVelocity.y);
        animator.SetBool("OnGround", isGround);

        groundCollider.enabled = isGround;
        airCollider.enabled = !isGround;

        if (Input.GetButtonDown("Use"))
        {
            Collider2D dialogueCharacter = Physics2D.OverlapCircle(transform.position, useRadius, useLayer);

            if (dialogueCharacter)
            {
                DialogueCharacter dc = dialogueCharacter.GetComponent<DialogueCharacter>();
                if (dc)
                {
                    dc.StartDialogue(SpriteRenderer);
                }
            }
        }

        if (knockbackTimer > 0)
        {
            knockbackTimer -= Time.deltaTime;
        }

    }
    
    public void UpdateScore(int scoreIncrease)
    {
        currentScore += scoreIncrease;
    }

    public void TakeKnockback(Vector2 hitDirection, float distance)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Collider2D collider = Physics2D.OverlapCircle(groundCheckObject.position, groundCheckRadius, groundCheckLayer);

        bool isGround = (collider != null);

        Vector2 knockback;
        if (!isGround)
        {
            knockback = new Vector2(hitDirection.x + distance, -100.0f);
        }
        else
        {
            knockback = new Vector2(hitDirection.x + distance, 200.0f);
        }
    
        knockbackTimer = knockbackDuration;
        rb.velocity = knockback;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheckObject != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(groundCheckObject.position, groundCheckRadius);
        }

        if (rb != null)
        {
            Vector3 velocity = rb.velocity;

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position + Vector3.up * 10.0f, transform.position + velocity + Vector3.up * 10.0f);
        }

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, useRadius);
    }
}
