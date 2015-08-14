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
		_intRandom = GetRandom();
		foreach(var num in _intRandom)
		{
			RoleFactory.CreateRoleWithIndex(num);
		}
	}

	public bool IsBonze()
	{
		if(_roles[0].RoleType != Role.ROLE_TYPE.roleType_bone)
		{
			return false;
		}else 
		{
			return true;
		}
	}
	public void MoveAllRoles()
	{
			// first will delete
			GameObject roleWillDelete = _roleObjs[0];
			iTween.MoveBy(roleWillDelete, iTween.Hash("x", -3.8f,  "time", 0.5f));
			// remove from roles
			_roleObjs.RemoveAt(0);
			_roles.RemoveAt(0);
			// delete self delay 1s
			DeleteSelf ds =roleWillDelete.GetComponent<DeleteSelf>();
			ds.StartDeleteMe();
			foreach(var roleObj in _roleObjs)
			{
				iTween.MoveBy(roleObj, iTween.Hash("x", -1.8f,  "time", 0.1f));
			}
			if(_roleObjs.Count <= 5)
			{
				Spawn();
			}
	}

	public void ChangeRoleSprite()
	{
		SpriteRenderer renderer = _roleObjs[0].GetComponent<SpriteRenderer>();
		renderer.sprite = GameController.Intance._otherRoleTextureHited[(int)(_roles[0].RoleType)];
	}


	public void OldBonzeDo(bool isHit)
	{
		if(isHit)
		{
			if(!GameController.Intance.IsBonze())
			{
				GameController.Intance.MoveAllRoles();
			}else 
			{
				OldBonzeAnimatorMgr._intance.SetScare();
				GameController._instance.ChangeRoleSprite();
			}
		}else 
		{
			OldBonzeAnimatorMgr._intance.SetWalk();
			if(GameController.Intance.IsBonze())
			{
				GameController.Intance.MoveAllRoles();
			}else
			{
				OldBonzeAnimatorMgr._intance.SetScare();
			}
		}
	}
}
