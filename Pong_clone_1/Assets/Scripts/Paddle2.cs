using UnityEngine;

public class Paddle2 : PaddleMovement
{
    protected override float GetMovementInput()
    {
        return Input.GetAxis("Player2Vertical");
    }
}
