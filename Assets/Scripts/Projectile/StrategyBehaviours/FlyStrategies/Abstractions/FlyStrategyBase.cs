using UnityEngine;

public abstract class FlyStrategyBase : IFlyable
{
    protected Rigidbody2D _projectileRigidbody;

    public FlyStrategyBase(Rigidbody2D projectileRigidbody)
    {
        _projectileRigidbody = projectileRigidbody;
    }

    public abstract void Fly(float flySpeed);
}