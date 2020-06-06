using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CtrlFase : MonoBehaviour {

	public Text displayContagem;
	public Text displayTimeOut;
	private float contagem = 61.0f;
	public Text displayCountBooks;
	public Personagem aluno;
	public int qtdLivro;

	void Awake() {
		var personagem = GameObject.FindWithTag ("Player");

		var camera = FindObjectOfType<CtrlCamera>();
		camera.alvo = personagem.transform;
	}
		
	void Start () {
		
	}

	public void contagemRegressiva(){
		if (contagem > 0.0f) {
			contagem -= Time.deltaTime;
			displayContagem.text = contagem.ToString ("00");
		} 
		else {
			gameOver ();
		}
	}

	public void verificarFimJogo(){
		if (qtdLivro == 45) {
			SceneManager.LoadScene("Congratulation");
		}
	}

	public void gameOver(){
		SceneManager.LoadScene("GameOver");
	}

	public void atualizarQtdLivros(){
		qtdLivro = aluno.obterTotalRecolhido ();
		displayCountBooks.text = qtdLivro.ToString ("00");
	}

	public void mobileBotaoPular(){
		aluno.setBtnVirtualPular (true);
	}
		
	void Update () {
		contagemRegressiva ();
		atualizarQtdLivros ();
		verificarFimJogo ();
	}
}