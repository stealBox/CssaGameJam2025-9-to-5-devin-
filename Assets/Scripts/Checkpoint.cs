using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Material materialDeactivated;
    public Material materialActivated;

    private new Renderer renderer;

    public bool activated = false;
    public Transform respawnPos;

    private respawn respawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = materialDeactivated;

        respawn = FindFirstObjectByType<respawn>().GetComponent<respawn>();
        
    }

    void CheckpointUpdate() {
        renderer.material = materialDeactivated;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            EventManager.instance.checkpointUpdate();
            renderer.material = materialActivated;

            activated = true;
            respawn.spawnPos = respawnPos;
        }
    }
}
