using UnityEngine;

public class GeneralFlyStrategy : FlyStrategyBase
{
    public GeneralFlyStrategy(Rigidbody2D projectileRigidbody) : base(projectileRigidbody)
    {

    }

    public override void Fly(float flySpeed)
    {
        _projectileRigidbody.velocity = _projectileRigidbody.transform.up * flySpeed;
    }
}
