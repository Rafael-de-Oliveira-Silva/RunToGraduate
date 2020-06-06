using UnityEngine;
using System.Collections;

public class Personagem : MonoBehaviour {

	public float velocidade; //atributo para velocidade no deslocamento do personagem.
	public float forcaPulo; //atibuto para força do pulo do personagem.
	private bool estaNoChao; //atributo para guardar se o personagem está no chão.
	private bool direita = true; //atributo para guardar se está virado para direita (true) ou esquerda (false)
	public Animator animator; //Atributo para acesso ao componente Animator do personagem para disparo das animações.
	public GameObject chaoVerificador; //Atributo para controle da posição do personagem. 
	private int livrosRecolhidos = 0; //Atibuto para acumular a quantidade de livros coletados pelo personagem.
	private bool btnVirtualPular;
	private bool btnVirtualAndarDireita;
	private bool btnVirtualAndarEsquerda;

	//Ao acordar irá marcar o objeto personagem com a tag "Player".
	void Awake(){
		gameObject.tag = "Player";
	}
		
	//Método construtor da classe Personagem.
	public Personagem(){
	
	}
		
	//Método para atualizar a quantidade de livros recolhidos pelo personagem.
	public void coletarLivros(int qtd){
		livrosRecolhidos += qtd;
	}

	//Método para recuperar o total de livros recolhidos pelo personagem.
	public int obterTotalRecolhido(){
		return livrosRecolhidos;
	}

	public void setBtnVirtualPular(bool valor){
		btnVirtualPular = valor;
	}

	public void setBtnVirtualAndarDireita(bool valor){
		btnVirtualAndarDireita = valor;
	}

	public void setBtnVirtualAndarEsquerda(bool valor){
		btnVirtualAndarEsquerda = valor;
	}

	//Método para que o personagem execute o movimento do pulo.
	public void pular(){
		//Verifica se há um objeto chamado "chaoVerificador" entre o personagem e chão (com a layer Piso).
		//Retornando true se o personagem estiver no chão.
		estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.transform.position, 1 << LayerMask.NameToLayer("Piso"));
		if ((Input.GetButtonDown("Jump") || btnVirtualPular) && estaNoChao)//Se o jogador pressionar a tecla "JUMP" (Espace) e o personagem estiver no chão
		{
			//Recupera o componente responsável pelas "leis da física" e adiciona uma força como parâmetro (posição atual x força do pulo) 
			GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
		}
			
		//Envia a mensagem ao animator do personagem para executar a animação do pulo. 
		animator.SetBool("estaNoChao", estaNoChao);
		btnVirtualPular = false;
	}

	//Método que será usado para rotacionar a posição do personagem na tela.
	//Fará o personagem virar de um lado para o outro.
	public void inverter()
	{
		float x = transform.localScale.x;
		x *= -1;
		transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
	}

	public void mover (){
		if (Input.GetAxisRaw ("Horizontal") > 0 || btnVirtualAndarDireita)  {
			if (!direita) //Verifica se não está virado para a direita
				inverter (); //Vira pra direita.

			//Realiza o deslocamento do personagem na cena para a direita.
			transform.Translate(Vector3.right * velocidade * Time.deltaTime);
			direita = true; //Atualiza o valor da variável.
		}

		//Verifica se o jogador pressionou o botão horizontal negativo
		if (Input.GetAxisRaw ("Horizontal") < 0 || btnVirtualAndarEsquerda) {
			if (direita) //Verifica se está virado para a direita
				inverter (); //Vira pra esquerda.

			//Realiza o deslocamento do personagem na cena para a esquerda (-Vector3.right)
			transform.Translate(-Vector3.right * velocidade * Time.deltaTime);
			direita = false; //Atualiza o valor da variável.
		}

		if (btnVirtualAndarDireita || btnVirtualAndarEsquerda) {
			animator.SetFloat ("velocidade", 1);
		} else {
			animator.SetFloat("velocidade", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
		}
	}
		
	//Será executado enquanto o personagem existir na cena.
	void Update () {
		if (!CtrlPause.getPausado ()) {
			pular ();
			mover ();
		}
	}
}