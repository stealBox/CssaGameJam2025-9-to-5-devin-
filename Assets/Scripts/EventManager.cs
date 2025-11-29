using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    //events for each power
    public static event Action powerDefault;
    public static event Action powerOne;
    public static event Action powerTwo;
    public static event Action powerThree;

    public static void powerRemove()
    {
        powerDefault?.Invoke();
    }
    public static void powerOneActivate()
    {
        powerOne?.Invoke();//this activates an event that methods can connect to
        //.invoke() calls every method that is "subscribed" to this event once
        //the ? means the same thing as if(powerOne != null)
    }

    public static void powerTwoActivate()
    {
        powerTwo?.Invoke();
    }

    public static void powerThreeAcivate()
    {
        powerThree?.Invoke();
    }

}
