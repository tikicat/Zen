using UnityEngine;
using System.Collections;

public class RoleFactory  {

	public static void CreateRoleWithIndex(int index)
	{
		Role role = new Role();
		if(index == 1)	
		{
			role._canHit = true;
			role.RoleType = Role.ROLE_TYPE.roleType_bone;
		}else if(index == 0)
		{
			role._canHit = false;
			role.RoleType = (Role.ROLE_TYPE)Random.Range(1,7);
		}
		GameController.Intance._roles.Add(role);

		Object obj = Resources.Load("Prefab/otherRole");
		GameObject otherRole = MonoBehaviour.Instantiate(obj) as GameObject;
		SpriteRenderer renderer = otherRole.GetComponent<SpriteRenderer>();
		renderer.sprite = GameController.Intance._otherRoleTextureNormal[(int)(role.RoleType)];

		otherRole.transform.position = new Vector3(-1 + (GameController.Intance._roles.Count - 1) * 1.8f, -2, -3);
	}
}
