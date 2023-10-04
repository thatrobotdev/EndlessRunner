using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float speed = 1F;

    // Update is called once per frame
    void Update()
    {
        // Move platform to the right, normalized to time
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;

        // Destroy platform when its position reaches -10
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }

    }
}
