using UnityEngine;
using System.Collections;

public class UI_Game : MonoBehaviour {
	public GameObject _btnHit;
	public GameObject _btnPass;
	public GameObject _btnPause;

	// Use this for initialization
	void Start () {
		UIEventListener.Get(_btnHit).onClick = ButtonHitCallBack;
		UIEventListener.Get(_btnPass).onClick = ButtonPassCallBack;
		UIEventListener.Get(_btnPause).onClick = ButtonPauseCallBack;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ButtonHitCallBack(GameObject button)
	{
		OldBonzeAnimatorMgr._intance.SetHit();
		GameController.Intance.CheckCurrentRole();
	}

	void ButtonPassCallBack(GameObject button)
	{
		OldBonzeAnimatorMgr._intance.SetWalk();
		GameController.Intance.CheckCurrentRole();
	}
	void ButtonPauseCallBack(GameObject button)
	{

	}
}
