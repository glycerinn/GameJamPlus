using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float scrollSpeed = 0.2f;

    private Material mat;
    private Vector2 offset = Vector2.zero;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        mat = spriteRenderer.material;
    }

    void Update()
    {
        offset.x += scrollSpeed * Time.deltaTime;
        mat.mainTextureOffset = offset;
    }
}
