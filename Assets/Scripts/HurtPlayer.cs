using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerManager.instance.DamagePlayer(1);
        }
    }
}
