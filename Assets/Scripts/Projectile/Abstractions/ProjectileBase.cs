using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _flySpeed;

    protected IFlyable _flyStrategy;
    protected IHittable _hitStrategy;

    private void Awake()
    {
        InitStrategies();
    }

    private void Update()
    {
        _flyStrategy.Fly(_flySpeed);
    }

    private void Hit(IDamageable damageableObject) 
    {
        _hitStrategy.Hit(damageableObject, _damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageableObject = collision.gameObject.GetComponent<IDamageable>();
        Hit(damageableObject);
    }

    protected abstract void InitStrategies();
}
