using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CtrlMenuPrincipal : MonoBehaviour {

	public GameObject painelPrincipal;
	public GameObject painelConfiguracoes;
	public Image btVolume;
	public CtrlCamera camera;

	void Awake() {
		if (!PlayerPrefs.HasKey("volume")) //Senão existir nenhuma informação já salva
			PlayerPrefs.SetInt("volume", 1); //Definimos o volume como ativo

		var volume = PlayerPrefs.GetInt("volume"); 
		var color = btVolume.color;
		if (volume == 1)
			color.a = 1f; //Alteramos o valor de alpha
		else
			color.a = 0.4f; //Alteramos o valor de alpha
		btVolume.color = color;
	}

	public void botaoNovoJogo() {
		SceneManager.LoadScene("Fase1");
	}

	public void botaoConfiguracoes() {
		painelPrincipal.SetActive(false);//Desativa o Painel Principal
		painelConfiguracoes.SetActive(true); //Ativa o Painel de Configurações
	}

	public void botaoCreditos(){
		SceneManager.LoadScene("Creditos");
	}

	public void botaoSair() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
		
	public void botaoVolume() {
		var volume = PlayerPrefs.GetInt("volume");  //Recupera informação sobre o som
		var color = btVolume.color;                 //Recupera a cor do botão
		if (volume == 1) {
			PlayerPrefs.SetInt("volume", 0);    //Salva a informação do volume
			color.a = 0.4f;                     //Torna o botão mais transparente
			camera.desabilitarSom();            //Desabilita o som
		} else {
			PlayerPrefs.SetInt("volume", 1);    //Salva a informação do volume
			color.a = 1f;                       //Torna o botão 100% visivel
			camera.habilitarSom();              //Habilita o som
		}
		btVolume.color = color;
	}

	public void botaoVoltar() {
		painelConfiguracoes.SetActive(false); //Desativa o Painel de Configurações
		painelPrincipal.SetActive(true);//Ativa o Painel Principal
	}
}
