using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, IControllable
{
    [SerializeField] protected float _moveSpeed;
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

    public void Rotate()
    {
        _rotateStrategy.Rotate();
    }

    public void Attack()
    {
        _attackStrategy.Attack();
    }

    protected abstract void InitStrategies();
}
