using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    const int MAX_HEALTH = 10;

    public static PlayerManager instance {get; private set;}

    private PlayerMovement playerStats;

    private int health;

    // Creates a new singleton and player stats
    void Awake()
    {
        Debug.Log("Creating manager");
        if (instance != null && instance != this) {
            Destroy(this);
        }
        else 
        {
            instance = this;
        }

        health = MAX_HEALTH;
        playerStats = GameObject.FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Changes a state of the player
    public void changeState(GlobalVars.Evolutions evo) {
        playerStats.changeEvo(evo);
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
