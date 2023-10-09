using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private UIController uiController;
    [SerializeField] private GameObject shield;
    
    [SerializeField] private float jumpForce = 10;
    private bool _jump;
    [SerializeField] private bool isGrounded;
    private float _lastYPos;
    public float distanceTravelled;
    public int coinsCollected;
    [SerializeField] private bool airJump;

    [SerializeField] private bool isShielded;
    
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
            //Debug.Log(hit.collider.name);
            Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.green);
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
            }
            else
            {
                // Death
                uiController.ShowGameOverScreen();
            }
            
        }
        
        // Always show game over, regardless of shielding when hitting DeathBox
        if (collision.transform.CompareTag("DeathBox"))
        {
            uiController.ShowGameOverScreen();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            coinsCollected++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("AirJump"))
        {
            airJump = true;
            Destroy(collision.gameObject);
        }

        if (!collision.CompareTag("ShieldPowerup")) return;
        isShielded = true;
        shield.SetActive(true);
        Destroy(collision.gameObject);
    }
}
