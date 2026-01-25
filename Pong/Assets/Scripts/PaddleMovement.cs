using JetBrains.Annotations;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * input * Time.deltaTime * speed);
    }
}
