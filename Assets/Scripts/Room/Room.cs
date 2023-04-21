using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviourPunCallbacks
{
    [SerializeField] private CharacterBase _characterPrefab;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private CharacterFactoryBase _characterFactory;

    private float _minPlayerSpawnX = -8;
    private float _maxPlayerSpawnX = 8;
    private float _minPlayerSpawnY = 0;
    private float _maxPlayerSpawnY = 3;

    private void Start()
    {
        SpawnCharacter();
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
    }

    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        Debug.Log($"Player {newPlayer} left room");
    }

    private void SpawnCharacter()
    {
        Vector2 spawnPoint = new Vector2(Random.Range(_minPlayerSpawnX, _maxPlayerSpawnX),
            Random.Range(_minPlayerSpawnY, _maxPlayerSpawnY));
        CharacterBase character = _characterFactory.Spawn(CharacterFactoryBase.CharacterType.General,
            spawnPoint, _playerData.Nickname);
        _playerInput.SetControllableObject(character);
    }
}
