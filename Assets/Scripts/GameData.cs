using UnityEngine;
using System.Collections;

public class GameData  {

	public static GameData _intance;

	// 当前玩家解锁了几个角色
	public int _hasUnlockRoleNum = 1;
	// 当前玩家分数
	private int _currentScore;
	// 玩家最高分
	private int _bestScore;
	// 玩家等级
	private int _level;
	public void LoadData()
	{
		_hasUnlockRoleNum = PlayerPrefs.GetInt("hasUnlockRoleNum");
		_currentScore = PlayerPrefs.GetInt("currentScore");
		_bestScore = PlayerPrefs.GetInt("bestScore");
		_level = PlayerPrefs.GetInt("level");
	}

	public void SavaData()
	{
		PlayerPrefs.SetInt("hasUnlockRoleNum", _hasUnlockRoleNum);
		PlayerPrefs.SetInt("bestScore", _bestScore);
		PlayerPrefs.SetInt("level", _level);
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

	public int BestScore
	{
		get{
			return _bestScore;
		}
		set {
			_bestScore = value;
		}
	}

	public int CurrentScore
	{
		get{
			return _currentScore;
		}
	}

	public void AddCurrentScore()
	{
		_currentScore += 1;
	}

	public int Level
	{
		get{
			return _level;
		}
	}

	public void AddLevel(int addLevel)
	{
		_level += addLevel;
	}
}
