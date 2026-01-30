using JetBrains.Annotations;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
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

    protected virtual float GetMovementInput()
    {
        return 0f;
    }
}
