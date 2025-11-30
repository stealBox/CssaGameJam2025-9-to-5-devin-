using UnityEngine;

public class WaterObject : MonoBehaviour
{
    public float textureScale = 0.125f;

    public float scrollSpeed = 0.5f;
    public float scrollScale = 0.2f;
    
    private Material material;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
        material.SetTextureScale("_BaseMap", new Vector2(transform.localScale.x * textureScale, transform.localScale.y * textureScale));
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = Mathf.Sin(Time.time * scrollSpeed) * scrollScale;
        float offsetY = Mathf.Cos(Time.time * scrollSpeed) * scrollScale;
        material.SetTextureOffset("_BaseMap", new Vector2(offsetX, offsetY));
    }
}
