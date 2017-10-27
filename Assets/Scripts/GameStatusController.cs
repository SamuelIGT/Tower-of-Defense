using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatusController : MonoBehaviour
{

	private bool hasGameStarted = false;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void SetGameStarted ()
	{
		if (this.hasGameStarted) {
			this.hasGameStarted = false;
		} else {
			this.hasGameStarted = true;
		}
	}

	public bool GetGameStarted ()
	{
		return this.hasGameStarted;
	}
}
