using UnityEngine;

public class HeadController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float rotateSpeed = 50.0F;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float smoothTime = 0.1F;

    // Update is called once per frame
    void Update()
    {
        // Rotate endlessly
        transform.Rotate(new Vector3(0F, rotateSpeed, 0F) * Time.deltaTime);
        
        // Get current transform position
        var currentTransformPosition = transform.position;

        // Get current player position y
        var currentPlayerPositionY = player.position.y;
        
        // Define a target position at the same y as the player
        var targetPosition = new Vector3(currentTransformPosition.x, currentPlayerPositionY, currentTransformPosition.z);

        transform.position = Vector3.SmoothDamp(currentTransformPosition, targetPosition, ref velocity, smoothTime);
        
    }
}
