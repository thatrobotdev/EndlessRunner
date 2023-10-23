using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float speed = 2F;

    // Update is called once per frame
    private void Update()
    {

        // Move platform to the right, normalized to time
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;

        // Destroy platform when its position falls behind the head
        if (transform.position.x < -30)
        {
            Destroy(gameObject);
        }

    }
}
