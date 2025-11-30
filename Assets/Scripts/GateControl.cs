using UnityEngine;

public class GateControl : MonoBehaviour
{
    public GameObject gateDoor;

    public bool defaultEvo;
    public bool evo1;
    public bool evo2;
    public bool evo3;

    GlobalVars.Evolutions stateToAllow;

    void Start()
    {
        EventManager.powerChanged += stateChange;
        if (evo1)
        {
            stateToAllow = GlobalVars.Evolutions.evo1;
        }else if (evo2)
        {
            stateToAllow = GlobalVars.Evolutions.evo2;
        }else if (evo3)
        {
            stateToAllow = GlobalVars.Evolutions.evo3;
        }
        else
        {
            stateToAllow = GlobalVars.Evolutions.defaultEvo;
        }
    }

    void stateChange()
    {
        if(PlayerManager.getState() == stateToAllow)
        {
            gateDoor.SetActive(false);
        }
        else
        {
            gateDoor.SetActive(true);
        }
    }

}
