using UnityEngine;
using System.Collections;

public class UI_Pause : MonoBehaviour {
	public GameObject _btnMain;
	public GameObject _btnResume;

	// Use this for initialization
	void Start () {
		UIEventListener.Get(_btnMain).onClick = ButtonMainCallBack;
		UIEventListener.Get(_btnResume).onClick = ButtonResumeCallBack;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ButtonMainCallBack(GameObject obj)
	{
		gameObject.SendMessageUpwards("ShowMainUI");
	}

	void ButtonResumeCallBack(GameObject obj)
	{
		GameController.Intance._gameIng = true;
		gameObject.SetActive(false);
	}
}
