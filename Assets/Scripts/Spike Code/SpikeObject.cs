using System;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeObject : MonoBehaviour
{
    private bool activated;
    private SpikeMover mover;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = false;
        mover = GetComponentInChildren<SpikeMover>();
    }

    public void activate()
    {
        if (!activated)
        {
            StartCoroutine(mover.moveSpike());
            activated = true;
        }
    }

    public void setNotActivated()
    {
        activated = false;
    }
}
