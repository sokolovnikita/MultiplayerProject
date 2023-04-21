using System.Collections;
using UnityEngine;

public class Coin : PickupObjectBase
{
    [SerializeField] int _cost;
    
    protected override void PickupAction(Collider2D collision)
    {
        collision.gameObject.GetComponent<ITakeableCoin>().TakeCoin(_cost);
        StartCoroutine(DisableForTime());
    }
}