using DG.Tweening;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    public Animator player;
    public SOString soStringName;

    [Header("Speed setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedrun;
    public float forceJump = 2;

    [Header("Animation Setup")]
    public float jumpscaleY = 1.5f;
    public float jumpscaleX = 1.5f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string Boolrun = "Run";
    public string triggerDeath = "Death";
    public float playerSwipeDuration = .1f;
   
}
