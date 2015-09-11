using UnityEngine;
using System.Collections;

public class UIManger : MonoBehaviour {

	public GameObject _mainUI;
	public GameObject _hudUI;
	public GameObject _pause;

	// Use this for initialization
	void Start () {
//		GameController.Intance.Init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void ShowMainUI()
	{
		_mainUI.SetActive(true);
		_pause.SetActive(false);
		_hudUI.SetActive(false);
	}

	void ShowPauseUI()
	{
		_mainUI.SetActive(false);
		_pause.SetActive(true);
	}
}
