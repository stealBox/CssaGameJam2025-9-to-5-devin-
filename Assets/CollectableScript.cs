using UnityEngine;


public class CollectableScript : MonoBehaviour
{
    public GameObject player;
    private GameObject currObj;

    public string typeOfCollectable;//replace this with an enum later if you can

    private bool state = true;//true == able to be collected, false == unable to be collected

    void Start()
    {
        currObj = this.gameObject;
    }

    void Update()
    {
        if (!state)//state will be changed in the player collider script for whenever it hits a gameObject with the collectible tag
        {
            currObj.SetActive(false);
        }
        else
        {
            currObj.SetActive(true);
        }
    }

}
