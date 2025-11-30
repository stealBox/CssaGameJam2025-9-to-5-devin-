using UnityEngine;

public class HelpMessage : MonoBehaviour
{
    private PlayerHud playerHud;

    [Multiline]
    public string message = "*You question what this help message was supposed to say...";

    public ParticleSystem particlesCollectible;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHud = GameObject.FindFirstObjectByType<PlayerHud>().GetComponent<PlayerHud>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            playerHud.ShowPopup(message);
            particlesCollectible.Play();
        }
    }
    
}
