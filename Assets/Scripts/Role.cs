using UnityEngine;
using System.Collections;

public class Role {

	public enum ROLE_TYPE
	{
		roleType_bone = 0,
		roleType_ninja,
		roleType_potted,
		roleType_geisha,
		roleType_tumbler,
		roleType_sumo,
		roleType_fish
	}

	public bool _canHit = false;

	private ROLE_TYPE _roleType;

	public ROLE_TYPE RoleType
	{
		get
		{
			return _roleType;
		}
		set 
		{
			_roleType = value;
		}
	}

}
