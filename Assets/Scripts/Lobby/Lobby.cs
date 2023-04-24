using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField _createRoom;
    [SerializeField] private TMP_InputField _joinRoom;
    [SerializeField] private TMP_InputField _nickname;
    [SerializeField] private PlayerData _playerData;

    public void CreateRoom()
    {
        SetPlayerData();
        Photon.Realtime.RoomOptions roomOptions = new Photon.Realtime.RoomOptions()
        {
            MaxPlayers = 10,
        };
        PhotonNetwork.CreateRoom(_createRoom.text, roomOptions);
    }

    public void JoinRoom()
    {
        SetPlayerData();
        PhotonNetwork.JoinRoom(_joinRoom.text);
    }

    public override void OnConnectedToMaster()
    {
        Log("Connected to Master");
    }

    public override void OnJoinedRoom()
    {
        Log($"Joined to the room {_joinRoom.text}");
        Log($"Your name is {_nickname.text}");
        SceneManager.LoadScene(2);
    }

    private void SetPlayerData()
    {
        _playerData.Nickname = _nickname.text;
    }

    private void Log(string message)
    {
        Debug.Log(message);
    }
}
