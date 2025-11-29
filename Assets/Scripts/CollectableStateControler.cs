using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CollectableStateControler : MonoBehaviour
{
    GameObject[] evo1Collectables;
    GameObject[] evo2Collectables;
    GameObject[] evo3Collectables;
    void Start()
    {
        evo1Collectables = GameObject.FindGameObjectsWithTag("Evo1");
        evo2Collectables = GameObject.FindGameObjectsWithTag("Evo2");
        evo3Collectables = GameObject.FindGameObjectsWithTag("Evo3");
    }
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in evo1Collectables)
        {
            obj.SetActive(GlobalVars.evo1PickUp);
        }
        foreach (GameObject obj in evo2Collectables)
        {
            obj.SetActive(GlobalVars.evo2PickUp);
        }
        foreach (GameObject obj in evo3Collectables)
        {
            obj.SetActive(GlobalVars.evo3PickUp);
        }
    }
}
