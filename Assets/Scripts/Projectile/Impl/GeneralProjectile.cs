public class GeneralProjectile : ProjectileBase
{
    protected override void InitStrategies()
    {
        _flyStrategy = new GeneralFlyStrategy(_rigidbody);
        _hitStrategy = new GeneralHitStrategy(this);
    }
}