using UnityEngine;
using System.Collections;

public class OldBonzeAnimatorMgr : MonoBehaviour {

	public static OldBonzeAnimatorMgr _intance;

	Animator _animator;

	public delegate void AnimationHandle();
	public AnimationHandle _animaionState;
	[HideInInspector]
	public bool _hitWrong = false;

	void Awake()
	{
		_intance = this;
		_animaionState = Idle;
	}

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(_animaionState != null)
		{
			_animaionState();
		}
	}

	public void Idle()
	{
		if(_animator.GetBool("walk") || _animator.GetBool("hit"))
		{
			_animator.SetBool("walk", false);
			_animator.SetBool("hit", false);
		}
	}

	public void Walk()
	{
		if(!_animator.GetBool("walk"))
		{
			_animator.SetBool("walk",true);
		}
		if(_animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
		{
			if(_hitWrong)
			{
				Scare();
			}else 
			{
				if(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f)
				{
					_animaionState = Idle;
				}
			}
		}
	}

	public void Hit()
	{
		if(!_animator.GetBool("hit"))
		{
			_animator.SetBool("hit",true);
		}
		if(_animator.GetCurrentAnimatorStateInfo(0).IsName("hit"))
		{
			if(_hitWrong)
			{
				Scare();
			}else 
			{
				if(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f)
				{
					_animaionState = Idle;
				}
			}
		}
	}

	public void Scare()
	{
		GameController.Intance._gameIng = false;
		GameController.Intance._gameOver = true;
		if(!_animator.GetBool("hitWrong"))
		{
			_animator.SetBool("hitWrong",true);
		}
	}

	// 状态切换
	public void SetHit()
	{
		_animaionState = Hit;
	}

	public void SetWalk()
	{
		_animaionState = Walk;
	}

	public void SetScare()
	{
		_animaionState = Scare;
	}
	
}
