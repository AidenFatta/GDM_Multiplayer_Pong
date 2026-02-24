using UnityEngine;

public class StartButton: MonoBehaviour
{
    private GameManager gameManager;
    private BallMovement Ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        Ball = FindAnyObjectByType<BallMovement>();

    }

    public void OnClick()
    {
        gameManager.RequestStart();
        Ball.StartMovement();
    }
}
