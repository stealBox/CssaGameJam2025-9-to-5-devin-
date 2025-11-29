using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private EnemyMovement enemyMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyMove = GetComponentInParent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyMove.setDetected(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            enemyMove.setDetected(false);
        }
    }
}
