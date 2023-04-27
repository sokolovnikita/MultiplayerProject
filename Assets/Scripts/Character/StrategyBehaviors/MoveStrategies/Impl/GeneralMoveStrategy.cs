using UnityEngine;

public class GeneralMoveStrategy : MoveStrategyBase
{
    public GeneralMoveStrategy(Rigidbody2D characterRigidbody) : base(characterRigidbody)
    {

    }

    public override void Move(Vector2 moveDirection, float moveSpeed)
    {
        Vector2 position = moveDirection * moveSpeed;
        _characterRigidbody.velocity = new Vector3(position.x, position.y, 0);
    }   
}