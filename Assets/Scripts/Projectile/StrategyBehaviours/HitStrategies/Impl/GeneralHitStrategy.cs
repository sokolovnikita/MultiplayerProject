using UnityEngine;

public class GeneralHitStrategy : HitStrategyBase
{
    public GeneralHitStrategy(ProjectileBase projectile) : base(projectile)
    {

    }

    public override void Hit(IDamageable damageableObject, int damage)
    {
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(damage);           
        }
    }
}