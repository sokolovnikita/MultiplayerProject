using UnityEngine;

public class GeneralHitStrategy : HitStrategyBase
{
    public override void Hit(IDamageable damageableObject, int damage)
    {
        damageableObject.TakeDamage(damage);
    }
}
