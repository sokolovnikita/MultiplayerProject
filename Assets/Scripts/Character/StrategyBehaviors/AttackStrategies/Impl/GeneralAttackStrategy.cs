using System.Collections;
using UnityEngine;

public class GeneralAttackStrategy : AttackStrategyBase
{
    private Coroutine attackCoroutine;

    public GeneralAttackStrategy(CharacterBase character, Transform firePointTransform) 
        : base(character, firePointTransform)
    {

    }

    public override void StartAttack(ProjectileFactoryBase projectileFactoryPrefab, 
        ProjectileFactoryBase.ProjectileType projectileType, float attackReload)
    {
        attackCoroutine = _character.StartCoroutine(Attacking(projectileFactoryPrefab, projectileType, attackReload));
    }

    public override void StopAttack()
    {
        _character.StopCoroutine(attackCoroutine);
    }

    private IEnumerator Attacking(ProjectileFactoryBase projectileFactoryPrefab,
        ProjectileFactoryBase.ProjectileType projectileType, float attackReload)
    {
        while (true) 
        {
            yield return new WaitForSeconds(attackReload);
            projectileFactoryPrefab.Spawn(projectileType, _firePointTransform.position,
                _character.transform.rotation);
        }       
    }
}