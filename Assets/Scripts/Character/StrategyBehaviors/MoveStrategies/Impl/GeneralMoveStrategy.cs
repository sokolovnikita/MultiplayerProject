using UnityEngine;

public class GeneralMoveStrategy : MoveStrategyBase
{
    public GeneralMoveStrategy(Transform characterTransform) : base(characterTransform)
    {

    }

    public override void Move(Vector2 moveDirection, float moveSpeed)
    {
        _characterTransform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }   
}
