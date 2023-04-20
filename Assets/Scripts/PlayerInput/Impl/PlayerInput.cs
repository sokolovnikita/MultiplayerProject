using Photon.Pun;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject _controllableGameObject;

    private IControllable _controllableObject;
    private NewInputSystem _newInputSystem;
    private PhotonView _photonView;

    private Vector2 _moveDirection;
    private Vector2 _rotateDirection;

    private void Awake()
    {       
        _newInputSystem = new NewInputSystem();
    }

    private void Start()
    {
        StartAttack();
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
        if (_photonView.IsMine)
        {
            ReadInput();
            Move();
            Rotate();
        }         
    }
    
    public void SetControllableObject(IControllable controllableObject)
    {
        _controllableObject = controllableObject;
        _photonView = _controllableObject.GetPhotonView();
    }

    private void Rotate()
    {
        if (_rotateDirection != new Vector2(0, 0))
            _controllableObject.Rotate(_rotateDirection);
    }

    private void Move() 
    {
        _controllableObject.Move(_moveDirection);
    }

    private void StartAttack()
    {
        _controllableObject.StartAttack();
    }

    private void StopAttack()
    {
        _controllableObject.StopAttack();
    }

    private void ReadInput()
    {
        _moveDirection = _newInputSystem.Player.Move.ReadValue<Vector2>();
        _rotateDirection = _newInputSystem.Player.Rotate.ReadValue<Vector2>();
    }
}