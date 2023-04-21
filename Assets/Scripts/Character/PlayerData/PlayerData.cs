using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player Data", order = 51)]
public class PlayerData : ScriptableObject
{
    [SerializeField] private string _nickname;

	public string Nickname
	{
		get { return _nickname; }
		set { _nickname = value; }
	}

}
