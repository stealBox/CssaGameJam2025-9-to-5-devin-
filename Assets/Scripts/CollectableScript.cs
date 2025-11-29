using System;
using UnityEngine;


public class CollectableScript : MonoBehaviour
{
    private GameObject currObj;

    public static event Action OnCollected;//event that can be activated and referanced elsewhere 
    //it is possible we could make an event for each "power"
    public string typeOfCollectable;//replace this with an enum later if you can

    private bool state = true;//true == able to be collected, false == unable to be collected

    void Start()
    {
        currObj = this.gameObject;
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
        currObj.SetActive(state);
    }

    void OnTriggerEnter(Collider colided)
    {
        if(colided.CompareTag("Player") && state)
        {
            state = false;
            OnCollected?.Invoke();
            //the ? means the same thing as if(OnCollected != null)
        }
    }

}
