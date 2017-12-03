﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarkUIIconController : MonoBehaviour
{
	private string scrollViewContentTag = "SCROLL_VIEW_CONTENT";
	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	public void notifyButtonWasClicked ()
	{
		GameObject.FindGameObjectWithTag (scrollViewContentTag).GetComponent<QuarksListController> ().removeQuark (this.gameObject.GetInstanceID ());
	}
}
