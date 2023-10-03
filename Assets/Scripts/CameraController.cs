using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 cameraVelocity;
    [SerializeField] private float smoothTime = 0.5F;

    // Update is called once per frame
    void Update()
    {
        // Smoothly follow player y

        // Define a target position preserving the camera's position but aimed at the player's y
        Vector3 targetPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);

        // Smoothy move the camera toward the player's y
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothTime);
    }
}
