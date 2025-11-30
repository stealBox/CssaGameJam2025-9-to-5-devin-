using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public static GlobalVars Instance { get; private set; }

    public enum Evolutions{
        defaultEvo,
        evo1,
        evo2,
        evo3
    }

    public static bool evo1PickUp = true;
    public static bool evo2PickUp = true;
    public static bool evo3PickUp = true;

    public int statsJumps = 0;
    public int statsLevels = 0;
    public int statsEvolved = 0;
    public int statsArms = 0;

    // Can we rename Collectibles to something else? Like evolutions?
    
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        LoadPrefs();
    }

    public void SavePrefs() {
        PlayerPrefs.SetInt("StatsJumps", statsJumps);
        PlayerPrefs.SetInt("StatsLevels", statsLevels);
        PlayerPrefs.SetInt("StatsEvolved", statsEvolved);
        PlayerPrefs.SetInt("StatsArms", statsArms);
    }
    
    public void LoadPrefs() {
        statsJumps = PlayerPrefs.GetInt("StatsJumps", 0);
        statsLevels = PlayerPrefs.GetInt("StatsLevels", 0);
        statsEvolved = PlayerPrefs.GetInt("StatsEvolved", 0);
        statsArms = PlayerPrefs.GetInt("StatsArms", 0);
    }
}
