using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField] private TMP_Text _loadingText;
    [SerializeField] private float _loadingTextAnimationSpeed;

    private List<string> _loadingTextList = new List<string>()
    {
        "Loading",
        "Loading.",
        "Loading..",
        "Loading...",
    };

    private int _currentLoadingAnimationIndex;

    private void Start()
    {
        SetStartSettings();
        StartCoroutine(LoadLobbyScene());
    }

    private void SetStartSettings()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "0.1";
        PhotonNetwork.ConnectUsingSettings();
    }

    private IEnumerator LoadLobbyScene()
    {
        while (!PhotonNetwork.IsConnectedAndReady) 
        {
            yield return new WaitForSeconds(_loadingTextAnimationSpeed);
            ChangeAnimation();
        }
        SceneManager.LoadScene(1);
    }

    private void ChangeAnimation()
    {
        _loadingText.text = _loadingTextList[_currentLoadingAnimationIndex];
        if (_currentLoadingAnimationIndex < _loadingTextList.Count - 1)
            _currentLoadingAnimationIndex += 1;
        else
            _currentLoadingAnimationIndex = 0;
    }
}
