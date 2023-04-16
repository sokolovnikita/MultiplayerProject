using System.Collections;
using UnityEngine;

public abstract class AttackStrategyBase : IAttackable
{
    protected CharacterBase _character;
    protected Transform _firePointTransform;

    public AttackStrategyBase(CharacterBase character, Transform firePointTransform)
    {
        _character = character;
        _firePointTransform = firePointTransform;
    }

    public abstract void StartAttack(ProjectileFactoryBase projectileFactoryPrefab, 
        ProjectileFactoryBase.ProjectileType projectileType, float attackReload);

    public abstract void StopAttack();
}
