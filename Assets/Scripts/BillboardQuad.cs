using UnityEngine;

public class BillboardQuad : MonoBehaviour
{
    // Update is called once per frame
    void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
