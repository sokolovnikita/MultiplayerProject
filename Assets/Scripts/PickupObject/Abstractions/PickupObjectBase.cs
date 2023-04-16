using UnityEngine;

public abstract class PickupObjectBase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickupAction(collision);
    }

    protected abstract void PickupAction(Collider2D collision);
}
