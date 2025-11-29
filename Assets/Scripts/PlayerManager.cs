using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    const int MAX_HEALTH = 10;

    public static PlayerManager instance {get; private set;}

    private PlayerMovement playerStats;

    private static GlobalVars.Evolutions playerState;

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

        playerState = GlobalVars.Evolutions.defaultEvo;
        health = MAX_HEALTH;
        playerStats = GameObject.FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();

        EventManager.powerOne += powerOneSet;
        EventManager.powerTwo += powerTwoSet;
        EventManager.powerThree += powerThreeSet;
        EventManager.powerDefault += powerDefaultSet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void powerOneSet()
    {
        GlobalVars.evo1PickUp = false;
        GlobalVars.evo2PickUp = true;
        GlobalVars.evo3PickUp = true;
        changeState(GlobalVars.Evolutions.evo1);
    }

    private void powerTwoSet()
    {
        GlobalVars.evo1PickUp = true;
        GlobalVars.evo2PickUp = false;
        GlobalVars.evo3PickUp = true;
        changeState(GlobalVars.Evolutions.evo2);
    }

    private void powerThreeSet()
    {
        GlobalVars.evo1PickUp = true;
        GlobalVars.evo2PickUp = true;
        GlobalVars.evo3PickUp = false;
        changeState(GlobalVars.Evolutions.evo3);
    }

    private void powerDefaultSet()
    {
        GlobalVars.evo1PickUp = true;
        GlobalVars.evo2PickUp = true;
        GlobalVars.evo3PickUp = true;
        changeState(GlobalVars.Evolutions.defaultEvo);
    }

    // Changes a state of the player
    public void changeState(GlobalVars.Evolutions evo) {
        playerState = evo;
        playerStats.changeEvo(evo);
    } 

    public static GlobalVars.Evolutions getState()
    {
        return playerState;
    }

    // Damages the player
    public void DamagePlayer(int damage) {
        health -= damage;
        Debug.Log("You took damage!");
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
        Debug.Log("You won!");
    }

    // What happens when the player loses
    private void LoseGame() {
        Debug.Log("You lost!");
    }
}
