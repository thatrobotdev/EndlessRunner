using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] Transform platformReferencePoint;
    private GameObject lastCreatedPlatform;

    void createNewPlatform()
    {
        lastCreatedPlatform = Instantiate(platformPrefab, platformReferencePoint.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        createNewPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        // Create a new platform when previous one's position reaches 0
        if(lastCreatedPlatform.transform.position.x < 0)
        {
            createNewPlatform();
        }
    }
}
