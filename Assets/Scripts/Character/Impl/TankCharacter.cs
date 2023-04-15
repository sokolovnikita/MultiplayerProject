using UnityEngine;

public class TankCharacter : CharacterBase
{
    protected override void InitStrategies()
    {
        _moveStrategy = new GeneralMoveStrategy(transform);
        _rotateStrategy = new GeneralRotateStrategy(transform);
    }
}