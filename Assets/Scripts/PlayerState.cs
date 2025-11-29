using UnityEngine;

public class PlayerState
{
    // Holds the different states a player can be in
    public GlobalVars.Evolutions state;

    public PlayerState(GlobalVars.Evolutions state) {
        this.state = state;
    }
}
