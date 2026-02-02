using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D myRigidbody;

    public Vector2 friction = new Vector2(.1f,0);

    public float speed;

    public float speedrun;

    public float forceJump = 2;

    private float _currentspeed;

    private void Update()
    {
        HandleJump();
        HandleMoviment();
        
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        _currentspeed = speedrun;
        else
        _currentspeed = speed;



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.linearVelocity = new Vector2(-_currentspeed, myRigidbody.linearVelocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.linearVelocity = new Vector2(_currentspeed, myRigidbody.linearVelocity.y);
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
        }
    }




}
