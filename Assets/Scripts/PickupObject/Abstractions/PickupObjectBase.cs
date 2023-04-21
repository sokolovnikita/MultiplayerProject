using System.Collections;
using UnityEngine;

public abstract class PickupObjectBase : MonoBehaviour
{
    [SerializeField] private int _disableTime;

    private SpriteRenderer _sprite;
    private BoxCollider2D _collider;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickupAction(collision);
    }

    protected IEnumerator DisableForTime()
    {
        _sprite.enabled = false;
        _collider.enabled = false;
        yield return new WaitForSeconds(_disableTime);
        _sprite.enabled = true;
        _collider.enabled = true;
    }

    protected abstract void PickupAction(Collider2D collision);
}
