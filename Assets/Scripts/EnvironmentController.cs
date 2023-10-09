using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] private GameObject[] environmentElement;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnvironmentElement());
    }

    IEnumerator CreateEnvironmentElement()
    {
        Instantiate(environmentElement[Random.Range(0, environmentElement.Length)], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(3, 6));
        StartCoroutine(CreateEnvironmentElement());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
