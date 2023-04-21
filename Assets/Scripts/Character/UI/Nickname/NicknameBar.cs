using TMPro;
using UnityEngine;

public class NicknameBar : MonoBehaviour
{
    [SerializeField] CharacterBase _character;

    private TMP_Text _nickname;

    private void Awake()
    {
        _nickname = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _character.OnChangedNicknameEvent += ChangeNickname;
    }

    private void OnDisable()
    {
        _character.OnChangedNicknameEvent -= ChangeNickname;
    }

    private void ChangeNickname(string nickname)
    {
        _nickname.text = nickname;
    }
}
