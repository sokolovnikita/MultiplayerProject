using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed;
    protected IMovable _moveStrategy;
    protected IAttackable _attackStrategy;
    protected IRotateable _rotateStrategy;

    private void Awake()
    {
        InitStrategies();
    }

    private void Update()
    {
        Move(GetInputDebug());
    }

    public void Move(Vector2 moveDirection)
    {
        _moveStrategy.Move(moveDirection, _moveSpeed);
    }

    public void Rotate()
    {
        _rotateStrategy.Rotate();
    }

    private void Attack()
    {
        _attackStrategy.Attack();
    }

    private Vector2 GetInputDebug()
    {
        Vector2 moveDirection = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
            moveDirection += new Vector2(0, 1);
        if (Input.GetKey(KeyCode.A))
            moveDirection += new Vector2(-1, 0);
        if (Input.GetKey(KeyCode.S))
            moveDirection += new Vector2(0, -1);
        if (Input.GetKey(KeyCode.D))
            moveDirection += new Vector2(1, 0);
        return moveDirection;
    }

    protected abstract void InitStrategies();
}
