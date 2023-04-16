using UnityEngine;

public abstract class ProjectileFactoryBase : MonoBehaviour
{
    public ProjectileBase Spawn(ProjectileType type, 
        Vector2 firePointTransform, Quaternion rotation)
    {
        ProjectileBase projectile = Instantiate(GetPrefab(type), firePointTransform, rotation);
        return projectile;
    }

    public enum ProjectileType
    {
        General
    }

    protected abstract ProjectileBase GetPrefab(ProjectileType type);
}