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
        if (state)
        {
            currObj.SetActive(true);
        }
        else
        {
            currObj.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider colided)
    {

        if(colided.tag == "Player")
        {
            state = false;
        }

    }

}
