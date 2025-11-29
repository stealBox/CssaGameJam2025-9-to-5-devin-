using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 1.0f;
    private Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            PlayerManager.instance.DamagePlayer(1);
        }
    }
}
