using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livro : MonoBehaviour {

	//Referência para o efeito sonoro 
	public AudioClip som1;

	//Ao acordar irá marcar o objeto livro com a tag "Books".
	void Awake(){
		gameObject.tag = "Books";
	}

	//Método colisor do objeto que será executado no primeiro frame que ocorrer a colisão
	void OnCollisionEnter2D(Collision2D colisor){
		if (colisor.gameObject.tag.Equals("Player")) { //Verifica se o objeto que colidiu possui a tag "Player" (personagem). 
			Debug.Log ("O " +colisor.gameObject.name+ " colidiu com o livro!!!"); //Exibe a mensagem no console de que o objeto colidiu.
			var personagem = colisor.gameObject.GetComponent<Personagem>(); //Pega a referência do objeto que colidiu.
			AudioSource.PlayClipAtPoint (som1, transform.position); //Executa o efeito sonoro ao colidir com o objeto com a tag "Player".
			personagem.coletarLivros (1); //Enviar a mensagem ao objeto informando a quantidade que será somada ao contador do personagem.
			Destroy (gameObject); //O objeto livro é destruido da cena.
		}
	}
}
