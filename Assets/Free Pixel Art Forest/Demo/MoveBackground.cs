using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {



	public float speed;
	private float x;
	public float PontoDeDestino;
	public float PontoOriginal;

	/*[SerializeField] private Vector2 parallaxEffectMultiplier;

	private Transform cameraTransform;
	private Vector3 lastCameraPositon;*/

	// Use this for initialization
	void Start () {
		//PontoOriginal = transform.position.x;
		/*cameraTransform = Camera.main.transform;
		lastCameraPositon = cameraTransform.position;*/
	}
	
	// Update is called once per frame
	void LateUpdate () {

		/*Vector3 deltaMovement = cameraTransform.position - lastCameraPositon;
		transform.positon += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.x * parallaxEffectMultiplier.x);
		lastCameraPositon =cameraTransform.position;*/

		x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);



		if (x <= PontoDeDestino){

			Debug.Log ("hhhh");
			x = PontoOriginal;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}


	}
}
