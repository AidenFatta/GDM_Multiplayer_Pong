using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {


    }
}

