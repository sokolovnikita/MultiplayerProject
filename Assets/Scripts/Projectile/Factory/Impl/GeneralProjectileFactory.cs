using UnityEngine;

public class GeneralProjectileFactory : ProjectileFactoryBase
{
    [SerializeField] private ProjectileBase _generalProjectilePrefab;

    protected override ProjectileBase GetPrefab(ProjectileType type)
    {
        switch (type)
        {
            case ProjectileType.General:
                return _generalProjectilePrefab;
        }
        Debug.LogError($"No prefab for: {type}");
        return _generalProjectilePrefab;
    }
}