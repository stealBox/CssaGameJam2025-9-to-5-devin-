using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager instance { get; private set; }

    //events for each power
    //this event goes when the power is changed
    public event Action powerChanged;
    //this goes when power is changed to default
    public event Action powerDefault;
    //this goes when power is evo1
    public event Action powerOne;
    //this --//-- is evo2
    public event Action powerTwo;
    //this --//-- is evo3
    public event Action powerThree;
    //this is activated when player dies
    public event Action playerDeath;
    //this is activated when a checkpoint is updated.
    public event Action checkpointUpdated;

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
        }
        else 
        {
            instance = this;
        }
    }

    public void powerUpdate(GlobalVars.Evolutions state)
    {
        Debug.Log("power update called");
        GlobalVars.Instance.statsEvolved++;
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

    public void playerDied()
    {
        Debug.Log("player died called");
        playerDeath?.Invoke();
        powerUpdate(GlobalVars.Evolutions.defaultEvo);
    }

    public void checkpointUpdate()
    {
        checkpointUpdated?.Invoke();
    }

}
