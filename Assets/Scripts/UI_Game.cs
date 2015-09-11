using UnityEngine;
using System.Collections;

public class UI_Game : MonoBehaviour {
	public GameObject _btnHit;
	public GameObject _btnPass;
	public GameObject _btnPause;
	public UIProgressBar _processBarTime;


	int[] _timeDownNum = {10,5,2};
	float[] _timeDownAdd = {5f / 12f,1f,1};
	int[] _timeDownScore = {200,400,500};
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

	void FixedUpdate()
	{
		if(GameController.Intance._gameIng)
		{
			_processBarTime.value -= Time.deltaTime / (float)_timeDownNum[_timeDownIndex];
		}
	}
	
	void AddTimeDown()
	{
		_processBarTime.value += (float)_timeDownAdd[_timeDownIndex] / (float)_timeDownNum[_timeDownIndex];
	}

	void CheckTimeWithScore()
	{	
		AddTimeDown();
		if(GameData.Intance.CurrentScore > _timeDownScore[_timeDownIndex])
		{
			_timeDownIndex = _timeDownIndex + 1 < 3 ? _timeDownIndex + 1 : _timeDownIndex;
		}
	}

	// 击打
	void ButtonHitCallBack(GameObject button)
	{
		if(GameController.Intance._gameOver)
			return;
		if(!GameController.Intance._gameIng)
		{
			GameController.Intance._gameIng = true;
		}
		CheckTimeWithScore();
		GameController.Intance.OldBonzeDo(true);
	}

	// 过
	void ButtonPassCallBack(GameObject button)
	{
		if(GameController.Intance._gameOver)
			return;
		if(!GameController.Intance._gameIng)
		{
			GameController.Intance._gameIng = true;
		}
		CheckTimeWithScore();
		GameController.Intance.OldBonzeDo(false);
	}	

	void ButtonPauseCallBack(GameObject button)
	{
		gameObject.SendMessageUpwards("ShowPauseUI");
		GameController.Intance._gameIng = false;
	}
}
