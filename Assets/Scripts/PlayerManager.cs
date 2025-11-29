using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    const int MAX_HEALTH = 10;

    public static PlayerManager instance {get; private set;}

    private PlayerState playerState;

    private int health;

    // Creates a new singleton and player stats
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this);
        }
        else 
        {
            instance = this;
        }

        health = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // NO TOUCHY!!! This is so that I connect the singleton to the player controller
    public void setPlayerState(PlayerState playerState) {
        this.playerState = playerState;
    }

    // Changes a state of the player
    public void changeState(GlobalVars.Collectables state) {
        playerState.state = state;
    } 

    // Damages the player
    public void DamagePlayer(int damage) {
        health -= damage;
        if (isDead()) {
            LoseGame();
        }
    }

    // Checks if player is dead
    private bool isDead() {
        return health <= 0;
    }

    // What happens when the player wins
    public void WinGame() {

    }

    // What happens when the player loses
    private void LoseGame() {

    }
}
