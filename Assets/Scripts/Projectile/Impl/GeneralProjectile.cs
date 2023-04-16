public class GeneralProjectile : ProjectileBase
{
    protected override void InitStrategies()
    {
        _flyStrategy = new GeneralFlyStrategy(transform);
        _hitStrategy = new GeneralHitStrategy();
    }
}
