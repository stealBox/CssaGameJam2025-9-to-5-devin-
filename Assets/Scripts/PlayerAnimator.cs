using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    enum AnimationState {
        Idle,
        Run,
        Jump
    }

    private const string ANIM_IDLE = "char_idle";
    private const string ANIM_RUN = "char_run";
    private const string ANIM_JUMP = "char_jump";

    private const float LEG_LERP_SPEED = 0.5f;

    private const float CHARACTER_Y_BASE = -1.075f;
    private const float CHARACTER_Y_EXTEND_SCALE = 1f;

    private const int BLENDSHAPE_LONGLEGS = 0;

    private new Animation animation;
    private AnimationState animationState = AnimationState.Idle;

    public PlayerMovement player;
    public SkinnedMeshRenderer characterMesh;
    public GameObject wingsMesh;
    public ParticleSystem particlesFeather;

    [Range(0f, 1f)]
    public float legScale = 0f;
    private float lastLegScale = 0f;

    private float legScaleLerp = 0f;
    private float legScaleLerpT = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animation = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastLegScale != legScale) {
            legScaleLerpT = 0f;
        }

        legScaleLerp = Mathf.Lerp(legScaleLerp, legScale, legScaleLerpT);
        characterMesh.SetBlendShapeWeight(BLENDSHAPE_LONGLEGS, legScaleLerp * 100f);
        legScaleLerpT += LEG_LERP_SPEED * Time.deltaTime;

        gameObject.transform.position = new Vector3(
                player.gameObject.transform.position.x, 
                player.gameObject.transform.position.y + CHARACTER_Y_BASE + legScaleLerp * CHARACTER_Y_EXTEND_SCALE, 
                player.gameObject.transform.position.z
            );

        if (player.grounded) {
            Vector3 xzMovement = Vector3.Scale(player.finalMove, new Vector3(1, 0, 1));
            if (xzMovement.magnitude > 0.0) {
                if (animationState != AnimationState.Run) {
                    animationState = AnimationState.Run;
                    animation.Blend(ANIM_RUN);

                    animation.Blend(ANIM_IDLE, 0.0f);
                    animation.Blend(ANIM_JUMP, 0.0f);
                }
            }
            else {
                if (animationState != AnimationState.Idle) {
                    animationState = AnimationState.Idle;
                    animation.Blend(ANIM_IDLE);
                    
                    animation.Blend(ANIM_RUN, 0.0f);
                    animation.Blend(ANIM_JUMP, 0.0f);
                }
            }
        }
        else {
            if (animationState != AnimationState.Jump) {
                animationState = AnimationState.Jump;
                animation.Blend(ANIM_JUMP);
                    
                animation.Blend(ANIM_IDLE, 0.0f);
                animation.Blend(ANIM_RUN, 0.0f);
            }
        }

        lastLegScale = legScale;
    }

    public void showWings() {
        wingsMesh.SetActive(true);
        particlesFeather.Play();
    }

    public void hideWings() {
        wingsMesh.SetActive(false);
        particlesFeather.Play();
    }
}
