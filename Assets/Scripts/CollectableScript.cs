using System;
using UnityEngine;


public class CollectableScript : MonoBehaviour
{
    private GameObject currObj;

    private GlobalVars.Evolutions typeOfCollectable;//replace this with an enum later if you can

    //allows for the dev to select type in inspector with check boxs
    public bool defaultEvo;//just incase...
    public bool evo1;
    public bool evo2;
    public bool evo3;

    void Start()
    {
        currObj = this.gameObject;
        if (evo1)
        {
            typeOfCollectable = GlobalVars.Evolutions.evo1;
        }else if (evo2)
        {
            typeOfCollectable = GlobalVars.Evolutions.evo2;
        }else if (evo3)
        {
            typeOfCollectable = GlobalVars.Evolutions.evo3;
        }
        else
        {
            typeOfCollectable = GlobalVars.Evolutions.defaultEvo;
        }
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider colided)
    {
        if(colided.CompareTag("Player"))
        {
            switch (typeOfCollectable)
            {
                case GlobalVars.Evolutions.evo1:
                    EventManager.powerOneActivate();
                    break;
                case GlobalVars.Evolutions.evo2:
                    EventManager.powerTwoActivate();
                    break;
                case GlobalVars.Evolutions.evo3:
                    EventManager.powerThreeAcivate();
                    break;
                default:
                    EventManager.powerRemove();
                    break;
            }
        }
    }

}
