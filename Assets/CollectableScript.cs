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

    }

    private void OnTriggerEnter(GameObject colided)
    {

        if(colided.tag == "Player")
        {
            currObj.SetActive(false);
        }

    }

}
