using System.Collections;
using UnityEngine;

public class breakableTile : MonoBehaviour
{
    public string animationFall = "breakableTile_anim_fall";
    public string animationReset = "breakableTile_anim_reset";

    public GameObject thisTile;
    public BoxCollider tileCollider;

    public Animation meshAnimation;
    private AudioSource audioFallSound;

    void Start() {
        audioFallSound = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enable();
        }
    }

    void enable()
    {
        //this is like the potato to TF2  (if you get that)

        // *I thought it was a coconut?
        StartCoroutine(coroutine());
    }

    IEnumerator coroutine()
    {
        audioFallSound.Play();
        meshAnimation.Play(animationFall);

        yield return new WaitForSeconds(0.09f);
        thisTile.SetActive(false);
        yield return new WaitForSeconds(5f);
        thisTile.SetActive(true);

        meshAnimation.Play(animationReset);
    }

}
