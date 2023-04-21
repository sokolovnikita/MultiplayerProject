using UnityEngine;

public class GeneralCharacterFactory : CharacterFactoryBase
{
    [SerializeField] private CharacterBase _generalCharacterPrefab;

    protected override CharacterBase GetPrefab(CharacterType type)
    {
        switch (type)
        {
            case CharacterType.General:
                return _generalCharacterPrefab;
        }
        Debug.LogError($"No prefab for: {type}");
        return _generalCharacterPrefab;
    }
}
