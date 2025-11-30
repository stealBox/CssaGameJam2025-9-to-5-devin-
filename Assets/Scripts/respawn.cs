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
        EventManager.instance.playerDeath += respawnPlayer;
        movement = playerObject.GetComponent<PlayerMovement>();
    }

    void respawnPlayer()
    {
        Debug.Log(movement);
        Debug.Log(playerObject);
        movement.DisableController();
        movement.getControllerTransform().position = spawnPos.position;
        movement.EnableController();
    }
}
