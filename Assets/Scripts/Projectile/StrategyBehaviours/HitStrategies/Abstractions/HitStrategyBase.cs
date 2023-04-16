using UnityEngine;

public abstract class HitStrategyBase : IHittable
{
    protected ProjectileBase _projectile;

    public HitStrategyBase(ProjectileBase projectile)
    {
        _projectile = projectile;
    }

    public abstract void Hit(IDamageable damageableObject, int damage);
}