using UnityEngine;

public class BackdropScroll : MonoBehaviour
{
    private SpriteRenderer _renderer;
    [SerializeField] private float speed = 1F;
    private float _offset;
    
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Create parallax effect by changing shader offset to move mountains
        _offset += Time.deltaTime * speed;
        _renderer.material.mainTextureOffset = new Vector2(_offset, 0);
    }
}
