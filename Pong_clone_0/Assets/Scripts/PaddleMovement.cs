using JetBrains.Annotations;
using UnityEngine;
using Unity.Netcode;

public abstract class PaddleMovement : NetworkBehaviour, ICollidable
{
    protected float speed = 5f;
    protected float maxSpeed = 7f;
    protected NetworkVariable<float> yPosition = new NetworkVariable<float>(0f);
    protected Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if (IsOwner)
        {
            float input = GetMovementInput();
            float newY = transform.position.y + (input * Time.deltaTime * speed); 
            transform.position = new Vector3(transform.position.x, newY, 0);
            yPosition.Value = transform.position.y;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, yPosition.Value, 0);
        }
              
        
    }

    protected abstract float GetMovementInput();

    public void OnHit(Collision2D collision)
    {
        Debug.Log("Paddle hit detected!");
    }
}
