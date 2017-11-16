using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuarksListController : MonoBehaviour
{
	public GameObject quarkIconShape;

	private List<GameObject> quarksIcon;
	private List<int> quarksList;
	private int lastIndex;
	public Color[] quarkColors;
	//	public float uiIconPadding = 10f;

	private enum Quarks
	{
		UP = 0,
		DOWN = 1,
		STRANGE = 2,
		CHARM = 3,
		BOTTOM = 4,
		TOP = 5}
	;

	// Use this for initialization
	void Start ()
	{
		quarksIcon = new List<GameObject> ();
		quarksList = new List<int> ();
		lastIndex = -1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void AddQuark (int quarkType)
	{
		GameObject go;
		switch (quarkType) {
		case (int)Quarks.UP: 
			go = Instantiate (quarkIconShape) as GameObject;
			break;
		case (int)Quarks.DOWN: 
			go = Instantiate (quarkIconShape) as GameObject;
			break;
		case (int)Quarks.STRANGE: 
			go = Instantiate (quarkIconShape) as GameObject;
			break;
		case (int)Quarks.CHARM: 
			go = Instantiate (quarkIconShape) as GameObject;
			break;
		case (int)Quarks.BOTTOM: 
			go = Instantiate (quarkIconShape) as GameObject;
			break;
		case (int)Quarks.TOP: 
			go = Instantiate (quarkIconShape) as GameObject;
			break;
		default: 
			go = Instantiate (quarkIconShape) as GameObject;
			break;
		}

		go.transform.SetParent (transform, false);
		go.GetComponent<Image> ().color = quarkColors [quarkType];

		/*if (lastIndex >= 0) {
			//localizar o ultimo
			Vector3 posicaoUltimo = quarksIcon [lastIndex].transform.position;
			//setar posição
			go.transform.position = posicaoUltimo + new Vector3 (uiIconPadding, 0, 0);
		} else {
			go.transform.position = transform.position;
		}*/

		//adicionar na lista
		quarksIcon.Add (go);
		quarksList.Add (quarkType);
		lastIndex++;
	
	}

	public List<int> GetQuarksList ()
	{
		return quarksList;
	}

	public int ListSize ()
	{
		return lastIndex;
	}
}
