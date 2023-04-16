using UnityEngine;

public abstract class FlyStrategyBase : IFlyable
{
    protected Transform _projectileTransform;

    public FlyStrategyBase(Transform projectileTransform)
    {
        _projectileTransform = projectileTransform;
    }

    public abstract void Fly(float flySpeed);
}