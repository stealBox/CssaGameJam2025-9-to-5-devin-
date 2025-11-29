using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]private float speed = 1.0f;
    private Transform target;
    private bool detected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        detected = false;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (detected)
        {
            float step = speed * Time.deltaTime;
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision deteced");
        if (collision.gameObject.CompareTag("Player")) {
            PlayerManager.instance.DamagePlayer(1);
        }
    }

    public void setDetected(bool detected)
    {
        this.detected = detected;
    }
}
