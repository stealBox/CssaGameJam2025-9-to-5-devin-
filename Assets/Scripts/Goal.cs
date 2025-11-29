using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision deteced");
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager.instance.WinGame();
        }
    }
}
