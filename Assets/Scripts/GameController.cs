using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class GameController : MonoBehaviour {
		



	public Sprite[] _otherRoleTextureNormal;
	public Sprite[] _otherRoleTextureHited;



	public static GameController _instance;

	private OldBonze _oldBonze;
	public List<Role> _roles;
	private string[] _strsRandom;
	private List<int> _intRandom;
	
	public static GameController Intance
	{
		get
		{
			if(_instance == null)
			{
				_instance = new GameController();
			}
			return _instance;
		}
	}

	void Awake()
	{
		_instance = this;
	}

	void Start()
	{
		_roles = new List<Role>();
		_intRandom = new List<int>();
		Init();
		_intRandom = GetRandom();
		Spawn();
	}


	public void Init()
	{
		ReadFile("game_random.txt");
	}

	public void ReadFile(string FileName)
	{
		string path = Application.dataPath + "/Resources/txt/";
		_strsRandom = File.ReadAllLines(path + FileName);
	}
	
	public List<int> GetRandom()
	{
		int index = Random.Range(0,9);
		string str = _strsRandom[index];
		List<int> randNums = new List<int>();
		for(int i = 0; i < str.Length; i ++)
		{
			randNums.Add(int.Parse(str.Substring(i,1)));
		}
		return randNums;
	}

	public void Spawn()
	{
		foreach(var num in _intRandom)
		{
			RoleFactory.CreateRoleWithIndex(num);
		}
	}
}
