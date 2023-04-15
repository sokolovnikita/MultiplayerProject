using UnityEngine;

public class GeneralRotateStrategy : RotateStrategyBase
{
    public GeneralRotateStrategy(Transform characterTransform) : base(characterTransform)
    {

    }

    public override void Rotate(Vector2 rotateDirection, float rotateSpeed)
    {
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, rotateDirection);
        _characterTransform.rotation = Quaternion.RotateTowards(_characterTransform.rotation, 
            rotation, rotateSpeed * Time.deltaTime);
    }
}
