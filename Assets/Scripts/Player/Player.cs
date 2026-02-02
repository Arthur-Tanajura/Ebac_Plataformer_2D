using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D myRigidbody;

    public Vector2 velocity;

    public float speed;

    

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.linearVelocity = new Vector2(-speed, myRigidbody.linearVelocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.linearVelocity = new Vector2(speed, myRigidbody.linearVelocity.y);
        }
    }
}
