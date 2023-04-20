using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviourPunCallbacks
{
    [SerializeField] private CharacterBase _characterPrefab;
    [SerializeField] private PlayerInput _playerInput;

    private void Start()
    {
        Vector2 offset = new Vector2(Random.Range(-8f, 8f), Random.Range(0f, 3f));
        CharacterBase character = PhotonNetwork.Instantiate(_characterPrefab.name, 
            offset, Quaternion.identity).GetComponent<CharacterBase>();
        _playerInput.SetControllableObject(character);
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
}
