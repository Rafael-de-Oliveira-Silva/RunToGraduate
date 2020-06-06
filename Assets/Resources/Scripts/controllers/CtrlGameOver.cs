using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CtrlGameOver : MonoBehaviour {

	public void botaoReiniciarSim(){
		SceneManager.LoadScene("Fase1");
	}

	public void botaoReiniciarNao(){
		SceneManager.LoadScene("Main");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
