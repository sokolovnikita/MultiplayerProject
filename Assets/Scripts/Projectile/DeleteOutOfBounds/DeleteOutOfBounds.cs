using UnityEngine;

public class DeleteOutOfBounds : MonoBehaviour
{
    private float _rightXBound = 15;
    private float _leftXBound = -15;
    private float _rightYBound = 15;
    private float _leftYBound = -15;

    private void Update()
    {
        if (transform.position.x > _rightXBound 
            || transform.position.x < _leftXBound
            || transform.position.y > _rightYBound
            || transform.position.y < _leftYBound)
        {
            Destroy(gameObject);
        }
    }
}
