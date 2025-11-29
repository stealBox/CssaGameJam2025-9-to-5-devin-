using UnityEngine;

public class PlayerState
{
    // Holds the different states a player can be in
    public GlobalVars.Collectables state;

    public PlayerState(GlobalVars.Collectables state) {
        this.state = state;
    }
}
