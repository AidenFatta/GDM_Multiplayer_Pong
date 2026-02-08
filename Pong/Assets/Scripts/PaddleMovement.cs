using JetBrains.Annotations;
using UnityEngine;

public abstract class PaddleMovement : MonoBehaviour, ICollidable
{
    protected float speed = 5f;
    protected float maxSpeed = 7f;
    protected Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float input = GetMovementInput();
        transform.Translate(Vector3.up * input * Time.deltaTime * speed);
    }

    protected abstract float GetMovementInput();

    public void OnHit(Collision2D collision)
    {
        Debug.Log("Paddle hit detected!");
    }
}
