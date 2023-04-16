public class TankCharacter : CharacterBase
{
    protected override void InitStrategies()
    {
        _moveStrategy = new GeneralMoveStrategy(transform);
        _rotateStrategy = new GeneralRotateStrategy(transform);
        _attackStrategy = new GeneralAttackStrategy(this, _firePoint.transform);
    }
}