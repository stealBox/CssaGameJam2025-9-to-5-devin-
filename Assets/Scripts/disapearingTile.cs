using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class disapearingTile : MonoBehaviour
{

    public GameObject thisTile;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enable();//this is held togther by hopes and dreams. very fragile
            //i hate coroutines
        }
    }

    void enable()
    {
        StartCoroutine(coroutine());
    }

    IEnumerator coroutine()
    {
        Debug.Log("co started");
        yield return new WaitForSeconds(2f);
        thisTile.SetActive(false);
        yield return new WaitForSeconds(5f);
        thisTile.SetActive(true);

    }

}
