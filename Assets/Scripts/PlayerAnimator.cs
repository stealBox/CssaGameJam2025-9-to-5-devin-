using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string ANIM_IDLE = "char_idle";
    private const string ANIM_RUN = "char_run";
    private const string ANIM_JUMP = "char_jump";

    public PlayerMovement player;
    private Animation animation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animation = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.grounded) {
            Vector3 xzMovement = Vector3.Scale(player.finalMove, new Vector3(1, 0, 1));
            if (xzMovement.magnitude > 0.0) {
                animation.Play(ANIM_RUN);
            }
            else {
                animation.Play(ANIM_IDLE);
            }
        }
        else {
            animation.Play(ANIM_JUMP);
        }
    }
}
