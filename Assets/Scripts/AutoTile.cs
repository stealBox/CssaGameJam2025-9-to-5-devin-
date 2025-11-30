using UnityEngine;

public class AutoTile : MonoBehaviour
{
    public float textureScale = 0.5f;

    private Material material;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
        material.SetTextureScale("_BaseMap", new Vector2(transform.localScale.z * textureScale, transform.localScale.y * textureScale));
    }

}
