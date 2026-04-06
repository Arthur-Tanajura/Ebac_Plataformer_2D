using UnityEngine;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public HealthBase healthBase;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;
    private bool _isRunning = false;
    private Animator _currentPlayer;
    public float playerSwipeDuration = .1f;
    private float _currentspeed;

    [Header("Jump Collision Ceck")]
    public Collider2D collider2D;
    public float distToGround;
    public float spaceToGround;
    public ParticleSystem jumpVFX;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;

        }
        _currentPlayer = Instantiate(soPlayerSetup.player, transform);

        if (collider2D != null)
        {
            distToGround = collider2D.bounds.extents.y;

        }
    }

    private bool IsGrounded()
    {
        Debug.DrawRay (transform.position, -Vector2.up, Color.magenta, distToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + spaceToGround);
    }
    
    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);
    }

    private void Update()
    {
        HandleJump();
        HandleMoviment();
        
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {

            _currentspeed = soPlayerSetup.speedrun;
            _currentPlayer.speed = 2;
        }

        else
        {
            _currentspeed = soPlayerSetup.speed;
            _currentPlayer.speed = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.linearVelocity = new Vector2(-_currentspeed, myRigidbody.linearVelocity.y);
            _currentPlayer.SetBool(soPlayerSetup.Boolrun, true);
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }

        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.linearVelocity = new Vector2(_currentspeed, myRigidbody.linearVelocity.y);
            _currentPlayer.SetBool(soPlayerSetup.Boolrun, true);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, playerSwipeDuration);
            }
        }

        else
        {
            _currentPlayer.SetBool(soPlayerSetup.Boolrun, false);
        }

        if (myRigidbody.linearVelocity.x>0)
        {
            myRigidbody.linearVelocity += soPlayerSetup.friction;
        }
        else if (myRigidbody.linearVelocity.x < 0)
        {
            myRigidbody.linearVelocity -= soPlayerSetup.friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.linearVelocity = Vector2.up * soPlayerSetup.forceJump;
            myRigidbody.transform.localScale = Vector2.one;
            DOTween.Kill(myRigidbody.transform);
            HandleScaleJump();
            PlayJumpVFX();
        }
    }

     private void PlayJumpVFX()
    {
        if (jumpVFX != null) jumpVFX.Play();
    }
    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(soPlayerSetup.jumpscaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        myRigidbody.transform.DOScaleX(soPlayerSetup.jumpscaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }

    internal void DestroyMe()
    {
        throw new NotImplementedException();
    }
}
