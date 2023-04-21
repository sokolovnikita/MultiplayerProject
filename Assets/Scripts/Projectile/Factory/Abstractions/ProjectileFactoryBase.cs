using Photon.Pun;
using UnityEngine;

public abstract class ProjectileFactoryBase : MonoBehaviour
{
    public ProjectileBase Spawn(ProjectileType type, 
        Vector2 firePointTransform, Quaternion rotation)
    {
        ProjectileBase projectile = PhotonNetwork.Instantiate
            (GetPrefab(type).name, firePointTransform, rotation).GetComponent<ProjectileBase>();
        return projectile;
    }

    public enum ProjectileType
    {
        General
    }

    protected abstract ProjectileBase GetPrefab(ProjectileType type);
}