using UnityEngine;
using System.Collections;

public class DeleteSelf : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartDeleteMe()
	{
		StartCoroutine("CoroutineDeleteMe");
	}

	IEnumerator CoroutineDeleteMe()
	{
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}
}
