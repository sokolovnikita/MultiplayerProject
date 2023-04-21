using Photon.Pun;
using UnityEngine;

public abstract class CharacterFactoryBase : MonoBehaviour
{
    public CharacterBase Spawn(CharacterType type, Vector2 spawnPoint, string nickname)
    {
        CharacterBase character = PhotonNetwork.Instantiate
            (GetPrefab(type).name, spawnPoint, Quaternion.identity).GetComponent<CharacterBase>();
        Debug.Log(nickname);
        character.Nickname = nickname;
        return character;
    }

    public enum CharacterType
    {
        General
    }

    protected abstract CharacterBase GetPrefab(CharacterType type);
}
