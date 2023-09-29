using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Player jump, adding instant force impulse to player rigidBody
            rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
    }
}
