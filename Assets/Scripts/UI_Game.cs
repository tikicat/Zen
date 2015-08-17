using UnityEngine;
using System.Collections;

public class UI_Game : MonoBehaviour {
	public GameObject _btnHit;
	public GameObject _btnPass;
	public GameObject _btnPause;
	public UIProgressBar _processBarTime;

	bool _gameStart = false;
	int[] _timeDownNum = {10,5,4,3,2,1};
	int _timeDownIndex = 0;

	// Use this for initialization
	void Start () {
		UIEventListener.Get(_btnHit).onClick = ButtonHitCallBack;
		UIEventListener.Get(_btnPass).onClick = ButtonPassCallBack;
		UIEventListener.Get(_btnPause).onClick = ButtonPauseCallBack;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixUpdate()
	{
		if(_gameStart)
		{
			_processBarTime.value -= Time.deltaTime / (float)_timeDownNum[_timeDownIndex];
		}
	}
	
	void StartTimeDown()
	{

	}

	void CheckTimeWithScore()
	{	

	}

	void ButtonHitCallBack(GameObject button)
	{
		GameController.Intance.OldBonzeDo(true);
	}
	
	void ButtonPassCallBack(GameObject button)
	{
		GameController.Intance.OldBonzeDo(false);
	}

	void ButtonPauseCallBack(GameObject button)
	{

	}
}
