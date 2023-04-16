using UnityEngine;

public abstract class ProjectileFactoryBase : MonoBehaviour
{
    public ProjectileBase Spawn(ProjectileType type, Vector2 firePointTransform, Quaternion rotation)
    {
        return Instantiate(GetPrefab(type), firePointTransform, rotation);
    }

    public enum ProjectileType
    {
        General
    }

    protected abstract ProjectileBase GetPrefab(ProjectileType type);
}