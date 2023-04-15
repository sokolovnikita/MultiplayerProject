using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    protected IMovable _moveStrategy;
    protected IAttackable _attackStrategy;
    protected IRotateable _rotateStrategy;

    private void Awake()
    {
        InitStrategies();
    }

    public void Move()
    {
        _moveStrategy.Move();
    }
  
    public void Rotate()
    {
        _rotateStrategy.Rotate();
    }

    private void Attack()
    {
        _attackStrategy.Attack();
    }

    protected abstract void InitStrategies();
}
