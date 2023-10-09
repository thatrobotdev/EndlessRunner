using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private bool isGrounded;
    private bool _jump;
    [SerializeField] private Animator anim;
    private float _lastYPos;
    public float distanceTravelled;
    [SerializeField] private UIController uiController;
    
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

    void CheckForJump()
    {
        if (_jump)
        {
            // Jump
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            _jump = false;
        }
    }

    void CheckForInput()
    {
        // On Space pressed, allow player to jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Player jump, adding instant force impulse to player rigidBody
            _jump = true;
            anim.SetTrigger(Jump);
        }
    }

    void CheckForGrounded()
    {
        // Cast a ray down from player to check if grounded
        var hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);
        
        // If player is above nothing
        if (hit.collider != null)
        {
            // Player is only grounded if ray hits ground close to player
            if (hit.distance < 0.1f)
            {
                // Ground is close to player, player is grounded
                isGrounded = true;
                anim.SetBool(IsGrounded, true);
            }
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
            uiController.ShowGameOverScreen();
        }
        
    }
}
