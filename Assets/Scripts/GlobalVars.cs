using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public enum Evolutions{
        defaultEvo,
        evo1,
        evo2,
        evo3
    }

    public static bool evo1PickUp = true;
    public static bool evo2PickUp = true;
    public static bool evo3PickUp = true;

    // Can we rename Collectibles to something else? Like evolutions?

}
