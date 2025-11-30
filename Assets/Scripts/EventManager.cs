using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    //events for each power
    //this event goes when the power is changed
    public static event Action powerChanged;
    //this goes when power is changed to default
    public static event Action powerDefault;
    //this goes when power is evo1
    public static event Action powerOne;
    //this --//-- is evo2
    public static event Action powerTwo;
    //this --//-- is evo3
    public static event Action powerThree;
    //this is activated when player dies
    public static event Action playerDeath;
    //this is activated when a checkpoint is updated.
    public static event Action checkpointUpdated;

    public static void powerUpdate(GlobalVars.Evolutions state)
    {
        GlobalVars.statsEvolved++;
        switch (state)
        {
            case GlobalVars.Evolutions.evo1:
                    powerOne?.Invoke();//this activates an event that methods can connect to
                    //.invoke() calls every method that is "subscribed" to this event once
                    //the ? means the same thing as if(powerOne != null)
                    break;
                case GlobalVars.Evolutions.evo2:
                    powerTwo?.Invoke();
                    break;
                case GlobalVars.Evolutions.evo3:
                    powerThree?.Invoke();
                    break;
                default:
                    powerDefault?.Invoke();
                    break;
        }
        powerChanged?.Invoke();
    }

    public static void playerDied()
    {
        playerDeath?.Invoke();
        powerUpdate(GlobalVars.Evolutions.defaultEvo);
    }

    public static void checkpointUpdate()
    {
        checkpointUpdated?.Invoke();
    }

}
