using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorFilaQuarks : MonoBehaviour {
	public GameObject prefabUp;
	public GameObject prefabDown;
	public GameObject prefabStrange;
	public GameObject prefabCharm;
	public GameObject prefabBottom;
	public GameObject prefabTop;
	enum Quarks{UP = 0,DOWN = 1,STRANGE =2,CHARM =3,BOTTOM =4,TOP =5};
	List<GameObject> listQuarks;
	public Vector3 distanciaEntreQuarks = Vector3.zero;
	public Vector3 posicaoInicial = Vector3.zero;
	int ultimoIndice;

	// Use this for initialization
	void Start () {
		listQuarks = new List<GameObject>();
		ultimoIndice = -1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddQuark(int quarkType) {
		GameObject go;
		switch (quarkType) {
		case (int)Quarks.UP: 
			go = Instantiate (prefabUp) as GameObject;
			break;
		case (int)Quarks.DOWN: 
			go = Instantiate (prefabDown) as GameObject;
			break;
		case (int)Quarks.STRANGE: 
			go = Instantiate (prefabStrange) as GameObject;
			break;
		case (int)Quarks.CHARM: 
			go = Instantiate (prefabCharm) as GameObject;
			break;
		case (int)Quarks.BOTTOM: 
			go = Instantiate (prefabBottom) as GameObject;
			break;
		case (int)Quarks.TOP: 
			go = Instantiate (prefabTop) as GameObject;
			break;
		default: 
			go = Instantiate (prefabUp) as GameObject;
			break;
		}

		//posicionando

		if (ultimoIndice >= 0) {
			//localizar o ultimo
			Vector3 posicaoUltimo = listQuarks[ultimoIndice].transform.position;
			//setar posição
			go.transform.position = posicaoUltimo + distanciaEntreQuarks;
		} else {
			go.transform.position = posicaoInicial;
		}
		//adicionar na lista
		listQuarks.Add (go);
		ultimoIndice++;
	}
}
