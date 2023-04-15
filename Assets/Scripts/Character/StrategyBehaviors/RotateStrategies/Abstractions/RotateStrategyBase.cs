using UnityEngine;
public abstract class RotateStrategyBase : IRotateable
{
    protected Transform _characterTransform;
    public RotateStrategyBase(Transform characterTransform)
    {
        _characterTransform = characterTransform;
    }

    public abstract void Rotate(Vector2 rotateDirection, float rotateSpeed);
}
