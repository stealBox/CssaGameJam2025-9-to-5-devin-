using UnityEngine;

public class respawn : MonoBehaviour
{

    private GameObject playerObject;
    public Transform spawnPos;
    private PlayerMovement movement;
    private bool respawnNow;

    void Start()
    {
        respawnNow = false;
        playerObject = this.gameObject;
        EventManager.playerDeath += respawnPlayer;
        movement = playerObject.GetComponent<PlayerMovement>();
    }

    void respawnPlayer()
    {
        movement.DisableController();
        movement.getControllerTransform().position = spawnPos.position;
        movement.EnableController();
    }
}
