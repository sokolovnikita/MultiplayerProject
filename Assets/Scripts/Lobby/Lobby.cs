using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField _createRoom;
    [SerializeField] private TMP_InputField _joinRoom;
    [SerializeField] private TMP_InputField _nickname;
    [SerializeField] private TMP_Text _debugLog;

    private void Start()
    {
        SetStartSettings();
    }

    public void CreateRoom()
    {
        Photon.Realtime.RoomOptions roomOptions = new Photon.Realtime.RoomOptions()
        {
            MaxPlayers = 2,
        };
        PhotonNetwork.CreateRoom(_createRoom.text, roomOptions);
    }

    public void JoinRoom()
    {
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
        SceneManager.LoadScene(1);
    }

    private void SetStartSettings()
    {
        PhotonNetwork.NickName = _nickname.text;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "0.1";
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Log(string message)
    {
        Debug.Log(message);
        _debugLog.text += message;
        _debugLog.text += "\n";
    }
}
