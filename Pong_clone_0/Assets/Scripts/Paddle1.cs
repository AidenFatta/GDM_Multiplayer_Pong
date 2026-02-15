using UnityEngine;

public class Paddle1 : PaddleMovement
{
    protected override float GetMovementInput()
    {
        return Input.GetAxis("Player1Vertical");
    }
}
