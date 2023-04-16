using UnityEngine;

public interface IControllable
{
    public void Move(Vector2 moveDirection);

    public void Rotate(Vector2 rotateDirection);

    public void StartAttack();

    public void StopAttack();
}