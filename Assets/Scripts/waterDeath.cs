using UnityEngine;

public class waterDeath : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.instance.playerDied();
        }
    }
}
