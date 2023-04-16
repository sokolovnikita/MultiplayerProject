using System.Collections;

public interface IAttackable
{
    public void StartAttack(ProjectileFactoryBase projectileFactoryPrefab,
        ProjectileFactoryBase.ProjectileType projectileType, float attackReload);

    public void StopAttack();
}
