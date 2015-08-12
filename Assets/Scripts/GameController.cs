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
	public  List<GameObject> _roleObjs;
	
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

	public void CheckCurrentRole()
	{
		if(_roles[0].RoleType != Role.ROLE_TYPE.roleType_bone)
		{

		}else 
		{
			foreach(var roleObj in _roleObjs)
			{
				iTween.MoveBy(roleObj, iTween.Hash("x", -1.8f,  "time", 0.1f));
			}
		}
	}

}
