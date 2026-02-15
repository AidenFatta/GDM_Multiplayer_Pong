using System.Runtime.CompilerServices;
using UnityEngine;

public class BallMovement : MonoBehaviour, ICollidable
{
    private Rigidbody2D rb;
    private Vector2 direction;
    private float speed = 3f;
    private float maxSpeed = 5f;

    public float Speed
    {
        get { return speed; }
        set 
        { 
            if (value > maxSpeed)
            {
                speed = maxSpeed;
            }
            else if (speed < 0)
            {
                speed = 0;
            }
            else
            {
                speed = value;
            }
        }
    }

    public Vector2 Direction
    {
        get { return direction; }
        set { direction = value.normalized; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(1f, 1f);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }

    public void OnHit(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        direction = Vector2.Reflect(direction, normal).normalized;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ICollidable collidable = collision.gameObject.GetComponent<ICollidable>();
        if (collidable == null)
        {
            collidable = collision.gameObject.GetComponentInParent<ICollidable>();
        }

        if (collidable != null)
        {
            collidable.OnHit(collision);
        }

        OnHit(collision);
    }
 
}

