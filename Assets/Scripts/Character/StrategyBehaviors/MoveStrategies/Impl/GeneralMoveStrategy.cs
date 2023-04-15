using UnityEngine;

public class GeneralMoveStrategy : MoveStrategyBase
{
    public GeneralMoveStrategy(Transform characterTransform) : base(characterTransform)
    {

    }

    public override void Move(Vector2 moveDirection, float moveSpeed)
    {
        Vector2 position = moveDirection * moveSpeed * Time.deltaTime;
        _characterTransform.position += new Vector3(position.x, position.y, 0);
    }   
}
