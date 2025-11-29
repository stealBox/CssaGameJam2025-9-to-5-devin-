using UnityEngine;

[CreateAssetMenu(fileName = "CollectableScript", menuName = "Scriptable Objects/CollectableScript")]
public class CollectableScript : ScriptableObject
{
    public bool state = true;//true == able to be collected, false == unable to be collected
}
