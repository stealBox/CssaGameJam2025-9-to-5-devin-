using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    const int MAX_HEALTH = 1;

    public static PlayerManager instance {get; private set;}

    private PlayerMovement playerStats;
    private PlayerHud playerHud;

    public static GlobalVars.Evolutions playerState;

    private int health;
    private bool dead = false;

    // Creates a new singleton and player stats
    void Start()
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
        playerStats = GameObject.FindFirstObjectByType<PlayerMovement>().GetComponent<PlayerMovement>();
        playerHud = GameObject.FindFirstObjectByType<PlayerHud>().GetComponent<PlayerHud>();

        EventManager.instance.powerOne += powerOneSet;
        EventManager.instance.powerTwo += powerTwoSet;
        EventManager.instance.powerThree += powerThreeSet;
        EventManager.instance.powerDefault += powerDefaultSet;
    }

    void LateUpdate()
    {
        if (dead)
        {
            EventManager.instance.playerDied();
        }
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
        playerHud.SetEvoText(evo);
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
        Scene currScene = SceneManager.GetActiveScene();
        GlobalVars.Instance.statsLevels++;
        if (currScene.name.Equals("Level1"))
        {
            SceneManager.LoadScene("LevelLab");
        }
        else if (currScene.name.Equals("LevelLab"))
        {
            SceneManager.LoadScene("Credits");
            GlobalVars.Instance.statsArms -= 1;
            // Win game
        }
    }

    // What happens when the player loses
    private void LoseGame() {
        Debug.Log("You lost!");
        health = MAX_HEALTH;
        EventManager.instance.playerDied();
    }

}
