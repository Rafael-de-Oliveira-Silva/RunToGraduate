using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystick2 : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler  {

	private Image bgImg;
	private Image joystickImg;
	private Vector3 inputVector;
	//public GameObject player;
	public float speed;
	public Personagem aluno;

	private void Start(){
		bgImg = GetComponent<Image> ();
		joystickImg = transform.GetChild (0).GetComponent<Image> ();

	}
	public virtual void OnDrag(PointerEventData ped){

		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImg.rectTransform
			, ped.position
			, ped.pressEventCamera
			, out pos)) 
		{
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

			inputVector = new Vector3(pos.x*3,0, pos.y*3);
			inputVector = (inputVector.magnitude > 1.0f)?inputVector.normalized:inputVector;

			// Move Joystick IMG
			joystickImg.rectTransform.anchoredPosition =
				new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x/3)
					,inputVector.z * (bgImg.rectTransform.sizeDelta.y/3));
		}
	}

	public virtual void OnPointerDown(PointerEventData ped){
		OnDrag (ped);

	}
	public virtual void OnPointerUp(PointerEventData ped){

		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	void Update(){
		if (joystickImg.transform.localPosition.x > 20) {
			aluno.setBtnVirtualAndarDireita (true);
		} else {
			aluno.setBtnVirtualAndarDireita (false);
		}

		if (joystickImg.transform.localPosition.x < -20) {
			aluno.setBtnVirtualAndarEsquerda (true);
		} else {
			aluno.setBtnVirtualAndarEsquerda (false);
		}


	}

}