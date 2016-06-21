using UnityEngine;
using System.Collections;

public class Pigeon : MonoBehaviour {

	//public float startwalkSpeed = 2.0f;
	//public float startwallLeft = 0.0f;
	//public float startwallRight = 5.0f;
	//public float startwalkingDirection = 1.0f;

	public float walkSpeed = 2.0f;
	public float wallLeft = 0.0f;
	public float wallRight = 5.0f;
	public float walkingDirection = 1.0f;

	public float _flight;
	public bool _groundAnimal;

	Vector3 walkAmount;

	void Start(){
	
		//walkSpeed = startwalkSpeed;
		//wallLeft = startwallLeft;
		//wallRight = startwallRight;
		//walkingDirection = startwalkingDirection;

	

	
	}

	// Update is called once per frame
	void Update () {


		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
		if (walkingDirection > 0.0f && transform.position.x >= wallRight)
			walkingDirection = -1.0f;
		else if (walkingDirection < 0.0f && transform.position.x < wallLeft)
			walkingDirection = 1.0f;
		transform.Translate(walkAmount);

	}

	void OnTriggerStay (Collider other)
	{
	
		if (other.tag == "Player") {
			if (other.GetComponentInChildren<Bark> ()._bark) {

				GetComponent<Rigidbody> ().useGravity = _groundAnimal;

				walkAmount.y = walkingDirection * walkSpeed * Time.deltaTime * _flight;
		
				walkSpeed = 7f;
				wallLeft = 500.0f;
				wallRight = 500.0f;
				walkingDirection = Random.Range (-1f, 1f);

			}
	
		}
	}
}
