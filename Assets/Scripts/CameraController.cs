using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 cameraVelocity;
    [SerializeField] private float smoothTime = 0.5F;
    [SerializeField] private bool lookAtPlayer = true;
    
    // Update is called once per frame
    void Update()
    {
        // Get current transform position
        Vector3 currentTransformPosition = transform.position;

        // Define a target position preserving the camera's position but aimed at the player's y
        Vector3 targetPosition = new Vector3(currentTransformPosition.x, player.position.y, currentTransformPosition.z);

        // Smoothly move the camera toward the player's y if the player is within camera limit
        if (targetPosition.y is > -7 and < 7)
        {
            transform.position = Vector3.SmoothDamp(currentTransformPosition, targetPosition, ref cameraVelocity, smoothTime);
        
            // Look at player to create 3D appearance
            if (lookAtPlayer)
            {
                transform.LookAt(player);
            }
        }
        
    }
}
