using UnityEngine;
public abstract class MoveStrategyBase : IMovable
{
    protected Rigidbody2D _characterRigidbody;

    public MoveStrategyBase(Rigidbody2D characterRigidbody)
    {
        _characterRigidbody = characterRigidbody;
    }

    public abstract void Move(Vector2 moveDirection, float moveSpeed);
}
