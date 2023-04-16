using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, IControllable, IDamageable, ITakeableCoin
{
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _rotateSpeed;
    [SerializeField] protected float _attackReload;
    [SerializeField] protected int _hitPoints;
    [SerializeField] protected int _coins;
    [SerializeField] protected ProjectileFactoryBase _projectileFactory;
    [SerializeField] protected ProjectileFactoryBase.ProjectileType _projectileType;
    [SerializeField] protected GameObject _firePoint;

    protected IMovable _moveStrategy;
    protected IAttackable _attackStrategy;
    protected IRotateable _rotateStrategy;

    private void Awake()
    {
        InitStrategies();
    }

    public void Move(Vector2 moveDirection)
    {
        _moveStrategy.Move(moveDirection, _moveSpeed);
    }

    public void Rotate(Vector2 rotateDirection)
    {
        _rotateStrategy.Rotate(rotateDirection, _rotateSpeed);
    }

    public void StartAttack()
    {
        _attackStrategy.StartAttack(_projectileFactory, _projectileType, _attackReload);
    }

    public void StopAttack()
    {
        _attackStrategy.StopAttack();
    }

    public void TakeDamage(int takenDamage)
    {
        if (_hitPoints - takenDamage > 0)
            _hitPoints -= takenDamage;
        else
            Destroy(gameObject);
    }

    public void TakeCoin(int takenCoins)
    {
        _coins += takenCoins;
    }

    protected abstract void InitStrategies();    
}