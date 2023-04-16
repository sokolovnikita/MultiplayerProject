using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject _controllableGameObject;

    private IControllable _controllableObject;
    private NewInputSystem _newInputSystem;

    private Vector2 _moveDirection;
    private Vector2 _rotateDirection;

    private void Awake()
    {
        _newInputSystem = new NewInputSystem();
        _controllableObject = _controllableGameObject.GetComponent<IControllable>();

        if (_controllableObject == null)
            Debug.LogError($"GameObject {_controllableGameObject} does not contain IControllable interface");
    }

    private void OnEnable()
    {
        _newInputSystem.Enable();
    }

    private void OnDisable()
    {
        _newInputSystem.Disable();
    }

    private void Update()
    {
        ReadInput();

        _controllableObject.Move(_moveDirection);
        if (_rotateDirection != new Vector2(0,0))
            _controllableObject.Rotate(_rotateDirection);
    }

    private void ReadInput()
    {
        _moveDirection = _newInputSystem.Player.Move.ReadValue<Vector2>();
        _rotateDirection = _newInputSystem.Player.Rotate.ReadValue<Vector2>();
    }
}
