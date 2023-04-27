using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _flySpeed;

    protected Rigidbody2D _rigidbody;
    protected IFlyable _flyStrategy;
    protected IHittable _hitStrategy;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        InitStrategies();
    }

    private void FixedUpdate()
    {
        _flyStrategy.Fly(_flySpeed);
    }

    private void Hit(IDamageable damageableObject) 
    {
        _hitStrategy.Hit(damageableObject, _damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageableObject = collision.gameObject.GetComponent<IDamageable>();
        if (damageableObject != null)
            Hit(damageableObject);
        Destroy(gameObject);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    protected abstract void InitStrategies();
}
