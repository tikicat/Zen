using UnityEngine;
using System.Collections;

public class GameData  {

	public static GameData _intance;


	public int _hasUnlockRoleNum = 1;
		

	public void LoadData()
	{
		_hasUnlockRoleNum = PlayerPrefs.GetInt("hasUnlockRoleNum");
	}

	public void SavaData()
	{
		PlayerPrefs.SetInt("hasUnlockRoleNum", _hasUnlockRoleNum);
	}

	public static GameData Intance
	{
		get{
			if(_intance == null)
			{
				_intance = new GameData();
			}
			return _intance;
		}
	}
}
