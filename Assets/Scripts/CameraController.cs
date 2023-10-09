using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 cameraVelocity;
    [SerializeField] private float smoothTime = 0.1F;
    [SerializeField] private bool lookAtPlayer = true;
    [SerializeField] private int upperLimit = 30;
    [SerializeField] private int lowerLimit = -2;

    // Update is called once per frame
    private void Update()
    {
        // Get current transform position
        var currentTransformPosition = transform.position;

        // Get current player position y
        var currentPlayerPositionY = player.position.y;

        // Smoothly move the camera toward the player's y if the player is within camera limit
        if (!(currentPlayerPositionY > lowerLimit) || !(currentPlayerPositionY < upperLimit)) return;
        
        // Define a target position preserving the camera's position but aimed at the player's y
        var targetPosition = new Vector3(currentTransformPosition.x, currentPlayerPositionY, currentTransformPosition.z);

        transform.position = Vector3.SmoothDamp(currentTransformPosition, targetPosition, ref cameraVelocity, smoothTime);
        
        // Look at player to create 3D appearance
        if (lookAtPlayer)
        {
            transform.LookAt(player);
        }

    }
}
