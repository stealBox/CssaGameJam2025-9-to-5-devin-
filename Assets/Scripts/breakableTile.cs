using System.Collections;
using UnityEngine;

public class breakableTile : MonoBehaviour
{
    public GameObject thisTile;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enable();
        }
    }

    void enable()
    {
        //this is like the potato to TF2  (if you get that)
        StartCoroutine(coroutine());
    }

    IEnumerator coroutine()
    {
        yield return new WaitForSeconds(0.09f);
        thisTile.SetActive(false);
        yield return new WaitForSeconds(5f);
        thisTile.SetActive(true);
    }

}
