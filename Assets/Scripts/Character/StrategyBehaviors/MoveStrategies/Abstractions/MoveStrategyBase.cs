using UnityEngine;
public abstract class MoveStrategyBase : IMovable
{
    protected Transform _characterTransform;
    public MoveStrategyBase(Transform characterTransform)
    {
        _characterTransform = characterTransform;
    }

    public abstract void Move(Vector2 moveDirection, float moveSpeed);
}
