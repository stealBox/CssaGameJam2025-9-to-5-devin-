using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpikeMover : MonoBehaviour
{
    private Vector3 basePos;
    private Vector3 activatedPos;
    [SerializeField] private float duration = 1f;
    [SerializeField] private float delay = 1f;
    [SerializeField] private float spikeHeight = 5.0f;

    private SpikeObject spikeObject;

    void Start()
    {
        basePos = transform.position;
        activatedPos = new Vector3(basePos.x, basePos.y + spikeHeight, basePos.z);

        spikeObject = GetComponentInParent<SpikeObject>();
    }

    public IEnumerator moveSpike()
    {
        yield return new WaitForSeconds(delay);

        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            float time = timeElapsed / duration;
            transform.position = Vector3.Lerp(basePos, activatedPos, time);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = activatedPos;

        yield return new WaitForSeconds(delay);

        timeElapsed = 0;

        while (timeElapsed < duration)
        {
            float time = timeElapsed / duration;
            transform.position = Vector3.Lerp(activatedPos, basePos, time);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        spikeObject.setNotActivated();
    }
}
