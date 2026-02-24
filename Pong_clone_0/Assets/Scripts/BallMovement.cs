using System.Runtime.CompilerServices;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UIElements;

public class BallMovement : NetworkBehaviour, ICollidable
{
    private Rigidbody2D rb;
    private Vector2 direction;
    private float speed = 3f;
    private float maxSpeed = 5f;
    protected NetworkVariable<Vector2> Position = new NetworkVariable<Vector2>();

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

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartMovement()
    {
        if (IsServer)
        {
            direction = new Vector2(1f, 1f);
        }
        
    }

    private void FixedUpdate()
    {
        if (IsServer)
        {
            rb.linearVelocity = direction * speed;
            Position.Value = rb.position;
        }
        else
        {
            transform.position = Position.Value;
        }
        
    }

    public void OnHit(Collision2D collision)
    {
        if (!IsServer) return;

        Vector2 normal = collision.contacts[0].normal;
        direction = Vector2.Reflect(direction, normal).normalized;
        if (collision.gameObject.CompareTag("Paddle"))
        {
            speed += 0.5f; 
            Debug.Log("Ball hit a paddle! Increasing speed to: " + speed);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsServer) return;

        Debug.Log("Collision detected with: " + collision.gameObject.name);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsServer) return;

        Debug.Log("Trigger detected with: " + collision.gameObject.name);
        transform.position = Vector2.zero;
        speed = 3f;
        if (collision.gameObject.CompareTag("Left Goal"))
        {
            direction = new Vector2(1f, 1f);
        }
        else if (collision.gameObject.CompareTag("Right Goal"))
        {
            direction = new Vector2(-1f, 1f);
        }
    }

}

