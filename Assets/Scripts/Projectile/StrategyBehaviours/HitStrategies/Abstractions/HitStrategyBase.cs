using UnityEngine;

public abstract class HitStrategyBase : IHittable
{
    public abstract void Hit(IDamageable damageableObject, int damage);
}