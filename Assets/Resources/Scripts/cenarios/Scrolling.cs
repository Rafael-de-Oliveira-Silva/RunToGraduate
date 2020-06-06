using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ćlasse para dá movimento aos objetos na cena do menu principal.
public class Scrolling : MonoBehaviour {

	//Velocidade que a imagem irá se mover
	public float velocidade; 

	//Material do Objeto com o Script
	private Material material; 

	void Start () {
		//recuperamos o material que está no Mesh Renderer
		material = GetComponent<Renderer>().material;
	}

	void Update () {
		//Acrescendo um novo valor ao offset Horizontalmente
		var x = Mathf.Repeat(Time.time * velocidade, 1); 
		//Define  esse novo offset
		var novoOffset = new Vector2(x, 0);             
		//aplica a alteração
		material.SetTextureOffset("_MainTex", novoOffset); 
	}
}
