using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{

    public Rigidbody2D myRigidbody;

    [Header("Speed setup")]
    public Vector2 friction = new Vector2(.1f,0);
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
    public Animator animator;
    public float playerSwipeDuration = .1f;
    private float _currentspeed;
    private bool _isRunning = false;

    private void Update()
    {
        HandleJump();
        HandleMoviment();
        
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {

            _currentspeed = speedrun;
            animator.speed = 2;
        }

        else
        {
            _currentspeed = speed;
            animator.speed = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.linearVelocity = new Vector2(-_currentspeed, myRigidbody.linearVelocity.y);
            animator.SetBool(Boolrun,true);
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }

        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.linearVelocity = new Vector2(_currentspeed, myRigidbody.linearVelocity.y);
            animator.SetBool(Boolrun,true);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, playerSwipeDuration);
            }
        }

        else
        {
            animator.SetBool(Boolrun, false);
        }

        if (myRigidbody.linearVelocity.x>0)
        {
            myRigidbody.linearVelocity += friction;
        }
        else if (myRigidbody.linearVelocity.x < 0)
        {
            myRigidbody.linearVelocity -= friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.linearVelocity = Vector2.up * forceJump;
            myRigidbody.transform.localScale = Vector2.one;
            DOTween.Kill(myRigidbody.transform);
            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(jumpscaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(jumpscaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
