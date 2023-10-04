using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 cameraVelocity;
    [SerializeField] private float smoothTime = 0.5F;

    // Update is called once per frame
    void Update()
    {
        // Get current transform position
        Vector3 currentTransformPosition = transform.position;

        // Define a target position preserving the camera's position but aimed at the player's y
        Vector3 targetPosition = new Vector3(currentTransformPosition.x, player.position.y, currentTransformPosition.z);

        // Smoothly move the camera toward the player's y
        transform.position = Vector3.SmoothDamp(currentTransformPosition, targetPosition, ref cameraVelocity, smoothTime);
    }
}
