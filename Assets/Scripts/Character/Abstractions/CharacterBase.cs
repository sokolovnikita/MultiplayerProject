using Photon.Pun;
using System;
using TMPro;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, IControllable, IDamageable, ITakeableCoin, IPunObservable
{
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _rotateSpeed;
    [SerializeField] protected float _attackReload;
    [SerializeField] protected int _actualHealthPoints;
    [SerializeField] protected int _maxHealthPoints;
    [SerializeField] protected int _actualCoins;
    [SerializeField] protected int _maxCoins;
    [SerializeField] protected ProjectileFactoryBase _projectileFactory;
    [SerializeField] protected ProjectileFactoryBase.ProjectileType _projectileType;
    [SerializeField] protected GameObject _firePoint;

    public event Action<int, int> OnTookDamageEvent;
    public event Action<int, int> OnTookCoinEvent;
    public event Action<string> OnChangedNicknameEvent;

    protected IMovable _moveStrategy;
    protected IAttackable _attackStrategy;
    protected IRotateable _rotateStrategy;

    private string _nickname;

    private void Awake()
    {
        InitStrategies();
    }

    public string Nickname
    {
        get 
        {
            return _nickname;
        }
        set 
        { 
            _nickname = value;
            OnChangedNicknameEvent(_nickname);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(_nickname);
        }
        else
        {
            _nickname = (string) stream.ReceiveNext();
        }
    }

    public void Move(Vector2 moveDirection)
    {
        _moveStrategy.Move(moveDirection, _moveSpeed);
    }

    public void Rotate(Vector2 rotateDirection)
    {
        _rotateStrategy.Rotate(rotateDirection, _rotateSpeed);
    }

    public void StartAttack()
    {
        _attackStrategy.StartAttack(_projectileFactory, _projectileType, _attackReload);
    }

    public void StopAttack()
    {
        _attackStrategy.StopAttack();
    }

    public void TakeDamage(int takenDamage)
    {       
        if (_actualHealthPoints - takenDamage > 0)
            _actualHealthPoints -= takenDamage;
        else
            Destroy(gameObject);
        OnTookDamageEvent(_maxHealthPoints, _actualHealthPoints);
    }

    public void TakeCoin(int takenCoins)
    {       
        _actualCoins += takenCoins;
        OnTookCoinEvent(_maxCoins, _actualCoins);
    }

    public PhotonView GetPhotonView()
    {
        return gameObject.GetComponent<PhotonView>();
    } 

    protected abstract void InitStrategies();   
}