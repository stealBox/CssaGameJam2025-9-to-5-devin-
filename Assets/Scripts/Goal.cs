using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision deteced");
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerManager.instance.WinGame();
        }
    }
}
