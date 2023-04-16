using UnityEngine;

public class GeneralFlyStrategy : FlyStrategyBase
{
    public GeneralFlyStrategy(Transform projectileTransform) : base(projectileTransform)
    {

    }

    public override void Fly(float flySpeed)
    {
        _projectileTransform.Translate(_projectileTransform.up * flySpeed * Time.deltaTime);
    }
}
