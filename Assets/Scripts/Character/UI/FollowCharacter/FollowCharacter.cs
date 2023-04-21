using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    [SerializeField] private CharacterBase _character;

    private void Update()
    {
        transform.position = _character.transform.position;
        transform.rotation = Quaternion.identity;
    }
}
