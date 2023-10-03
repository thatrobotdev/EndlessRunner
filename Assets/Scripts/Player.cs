using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 0F;

    // Update is called once per frame
    void Update()
    {
        // On Space pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Player jump, adding instant force impulse to player rigidBody
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
