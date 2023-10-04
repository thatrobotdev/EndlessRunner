using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] Transform platformReferencePoint;
    private GameObject _lastCreatedPlatform;

    void CreateNewPlatform()
    {
        _lastCreatedPlatform = Instantiate(platformPrefab, platformReferencePoint.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateNewPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        // Create a new platform when previous one's position reaches 0
        if(_lastCreatedPlatform.transform.position.x < 0)
        {
            CreateNewPlatform();
        }
    }
}
