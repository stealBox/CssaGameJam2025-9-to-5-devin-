using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    private SpikeObject spikeObject;
    private void Start()
    {
        spikeObject = GetComponentInParent<SpikeObject>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spikeObject.activate();
        }
    }
}
