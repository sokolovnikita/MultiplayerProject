using Photon.Pun;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject _controllableGameObject;

    private IControllable _controllableObject;
    private NewInputSystem _newInputSystem;
    private PhotonView _photonView;
    private bool _isInputEnable = false;

    private Vector2 _moveDirection;
    private Vector2 _rotateDirection;

    private void Awake()
    {       
        _newInputSystem = new NewInputSystem();
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
        if (_photonView.IsMine && _isInputEnable)
        {
            ReadInput();
            Rotate();           
        }         
    }

    private void FixedUpdate()
    {
        if (_photonView.IsMine && _isInputEnable)
        {
            Move();
        }
    }

    public void SetInputEnable()
    {
        _isInputEnable = true;
        StartAttack();
    }

    public void SetInputDisable()
    {
        _isInputEnable = false;
        StopAttack();
    }

    public void SetControllableObject(IControllable controllableObject)
    {
        _controllableObject = controllableObject;
        _photonView = _controllableObject.GetPhotonView();
    }

    private void Rotate()
    {
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