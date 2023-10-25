using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField] private GameObject lastCreatedPlatform;
    [SerializeField] private float spaceBetweenPlatforms = 2F;
    private float _lastPlatformWidth;

    // Update is called once per frame
    private void Update()
    {

        // Only create a new platform when previous one's position is before the platform spawner
        if (!(lastCreatedPlatform.transform.position.x < transform.position.x)) return;
        float randomSpaceInBetweenPlatforms = Random.Range(2, 5);
        var targetPlatformX = transform.position.x + _lastPlatformWidth + randomSpaceInBetweenPlatforms;
        var targetCreationPoint = new Vector3(targetPlatformX, 0, 0);

        // Create target for new platform
        var platformType = Random.Range(0, platformPrefabs.Length);
        lastCreatedPlatform = Instantiate(platformPrefabs[platformType], targetCreationPoint, Quaternion.identity);

        _lastPlatformWidth = lastCreatedPlatform.GetComponent<BoxCollider2D>().bounds.size.x;
    }
}
