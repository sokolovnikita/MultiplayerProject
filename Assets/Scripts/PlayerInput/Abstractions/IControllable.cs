using UnityEngine;

public interface IControllable
{
    public void Move(Vector2 moveDirection);

    public void Rotate();

    public void Attack();
}
