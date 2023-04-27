public class TankCharacter : CharacterBase
{
    protected override void InitStrategies()
    {
        _moveStrategy = new GeneralMoveStrategy(_rigidbody);
        _rotateStrategy = new GeneralRotateStrategy(transform);
        _attackStrategy = new GeneralAttackStrategy(this, _firePoint.transform);
    }
}