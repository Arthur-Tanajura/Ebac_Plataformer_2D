using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector2 direction;

    public float timeToDestroy = 3f;


    private void Awake()
    {
        Destroy(gameObject,timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(direction*Time.deltaTime);
    }

}
