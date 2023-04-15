using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject _controllableGameObject;

    private IControllable _controllableObject;
    private NewInputSystem _newInputSystem;

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
        _controllableObject.Move(_newInputSystem.Player.Move.ReadValue<Vector2>());
    }
}
