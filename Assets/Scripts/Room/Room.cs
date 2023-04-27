using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Room : MonoBehaviourPunCallbacks
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private CharacterFactoryBase _characterFactory;
    [SerializeField] private TMP_Text _winText;

    private CharacterBase _character;
    private float _minPlayerSpawnX = -8;
    private float _maxPlayerSpawnX = 8;
    private float _minPlayerSpawnY = 0;
    private float _maxPlayerSpawnY = 3;
    private int _playersCountToStart = 1;
    private int _playersCountToEnd = 0;

    private void Start()
    {
        SpawnCharacter();
    }

    private void Update()
    {
        CheckForEndGame();
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"Player {newPlayer} entered room");
        CheckForStartGame();
    }

    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        Debug.Log($"Player {newPlayer} left room");
    }

    private void SpawnCharacter()
    {
        Vector2 spawnPoint = new Vector2(Random.Range(_minPlayerSpawnX, _maxPlayerSpawnX),
            Random.Range(_minPlayerSpawnY, _maxPlayerSpawnY));
        _character = _characterFactory.Spawn(CharacterFactoryBase.CharacterType.General,
            spawnPoint, _playerData.Nickname);    
        _playerInput.SetControllableObject(_character);
        _character.OnCharacterDiedEvent += CheckForEndGame;
        _character.OnCharacterDiedEvent += LeaveRoom;
           
        CheckForStartGame();
    }

    private void CheckForStartGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount >= _playersCountToStart)
        {
            _playerInput.SetInputEnable();
        }          
    }

    private void CheckForEndGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount <= _playersCountToEnd)
        {
            _playerInput.SetInputDisable();
            _winText.text = $"Победил игрок {_character.Nickname} с {_character.Coins} монетами";
        }      
    }
}
