using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CtrlPause : MonoBehaviour {

	public GameObject menu;
	private static bool pause = false;

	void Start (){
		menu.SetActive (false);
	}

	public static bool getPausado() {
		return pause;
	}

	public void botaoVoltar() {
		Time.timeScale = 1f;
		menu.SetActive(false);
		pause = false;
	}

	public void botaoMenuPrincipal() {
		Time.timeScale = 1f;
		SceneManager.LoadScene("Main");
		menu.SetActive(false);
		pause = false;
	}

	public void botaoPause(){
		pause = true;
	}

	void Update() {
		if (pause) {
			menu.SetActive(true);
			Time.timeScale = 0f;
		}  
	}
}
