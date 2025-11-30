using UnityEngine;

public class respawn : MonoBehaviour
{

    private GameObject playerObject;
    public Transform spawnPos;
    private PlayerMovement movement;

    void Start()
    {
        playerObject = this.gameObject;
        EventManager.playerDeath += respawnPlayer;
        movement = playerObject.GetComponent<PlayerMovement>();
    }

    void respawnPlayer()
    {
        Debug.Log("gets here?");
        //movement.enabled = false;
        playerObject.transform.position = spawnPos.position;
        //movement.enabled = true;
    }

}
