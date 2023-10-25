using UnityEngine;

public class Player : MonoBehaviour
{
    public float distanceTravelled;
    public int coinsCollected;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private UIController uiController;
    [SerializeField] private GameObject shield;
    [SerializeField] private SFXManager sfxManager;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool airJump;
    [SerializeField] private bool isShielded;

    private bool _jump;
    private float _lastYPos;

    private static readonly int Falling = Animator.StringToHash("Falling");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");

    private void Start()
    {
        _lastYPos = transform.position.y;
    }

    // Update is called once per frame
    private void Update()
    {
        distanceTravelled += Time.deltaTime;
        CheckForInput();
        CheckIfPlayerIsFalling();
    }

    private void FixedUpdate()
    {
        CheckForGrounded();
        CheckForJump();
    }

    private void CheckIfPlayerIsFalling()
    {
        // Get current position
        var currentYPos = transform.position.y;

        // Animate falling if falling
        anim.SetBool(Falling, currentYPos < _lastYPos);

        // Update last y position
        _lastYPos = currentYPos;
    }

    private void CheckForJump()
    {
        if (!_jump) return;

        // Jump
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        sfxManager.PlaySFX("Jump");
        _jump = false;
    }

    private void CheckForInput()
    {
        // If player is either on the ground or has the Air Jump power-up
        if (!isGrounded && !airJump) return;

        // On Space pressed, allow player to jump
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        // Use power-up if in air
        if (airJump && !isGrounded)
        {
            airJump = false;
            sfxManager.PlaySFX("DoubleJump");
        } else
        {
            sfxManager.PlaySFX("Jump");
        }

        // Player jump, adding instant force impulse to player rigidBody
        _jump = true;
        
        anim.SetTrigger(Jump);
    }

    private void CheckForGrounded()
    {
        // Cast a ray down from player to check if grounded
        var hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);

        // If player is above something that isn't an obstacle
        if (hit.collider != null && !hit.collider.CompareTag("Obstacle"))
        {
            // Player is only grounded if ray hits ground close to player
            if (hit.distance < 0.1f)
            {
                // Ground is close to player, player is grounded
                isGrounded = true;
                anim.SetBool(IsGrounded, true);
            }
            else
            {
                isGrounded = false;
            }
        }
        else
        {
            // Ground is far from player, player is not grounded
            isGrounded = false;
            anim.SetBool(IsGrounded, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player collides with an obstacle
        if (collision.transform.CompareTag("Obstacle"))
        {
            if (isShielded)
            {
                // Use shield
                isShielded = false;
                shield.SetActive(false);
                sfxManager.PlaySFX("ShieldBreak");
            }
            else
            {
                killPlayer();
            }
        }
        else
        {
            sfxManager.PlaySFX("Land");
        }

        // Always show game over, regardless of shielding when hitting DeathBox
        if (collision.transform.CompareTag("DeathBox"))
        {
            killPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            coinsCollected++;
            sfxManager.PlaySFX("Coin");
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("AirJump"))
        {
            airJump = true;
            sfxManager.PlaySFX("PowerupDoubleJump");
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("ShieldPowerup"))
        {
            isShielded = true;
            shield.SetActive(true);
            sfxManager.PlaySFX("PowerupShield");
            Destroy(collision.gameObject);
        }

    }

    private void killPlayer()
    {
        sfxManager.PlaySFX("GameOverHit");
        uiController.ShowGameOverScreen();
    }
}
