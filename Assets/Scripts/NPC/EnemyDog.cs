using UnityEngine;
using System.Collections;

public class EnemyDog : MonoBehaviour {



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

	bool isGrowling;
	bool isFleeing = false;

	Collider2D lineofsight;
	SpriteRenderer enemydogsr;
	GameObject player;
	Animator enemydoganim;

	void Start(){
		lineofsight = this.GetComponentInChildren<Collider2D> ();
		enemydogsr = this.GetComponentInChildren<SpriteRenderer> ();
		player = GameObject.FindWithTag ("Player");
		enemydoganim = this.GetComponentInChildren<Animator> (); 

		//walkSpeed = startwalkSpeed;
		//wallLeft = startwallLeft;
		//wallRight = startwallRight;
		//walkingDirection = startwalkingDirection;




	}

	// Update is called once per frame
	void Update () {

		PlayerCheck ();



		if (!isGrowling || isFleeing) 
		{
			walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
			if (walkingDirection > 0.0f && transform.position.x >= wallRight) {
				walkingDirection = -1.0f;
				enemydogsr.flipX = true;
			} else if (walkingDirection < 0.0f && transform.position.x < wallLeft) {
				walkingDirection = 1.0f;
				enemydogsr.flipX = false;
			}
			transform.Translate (walkAmount);
		}


	}
		

	void Flee()
	{
		isFleeing = true;
		GetComponent<Rigidbody> ().useGravity = _groundAnimal;

		walkAmount.y = walkingDirection * walkSpeed * Time.deltaTime * _flight;

		walkSpeed = 7f;
		wallLeft = 500.0f;
		wallRight = 500.0f;

		if (this.transform.position.x > player.transform.position.x) {
			walkingDirection = 1;
			enemydogsr.flipX = false;
		} else 
		{
			walkingDirection = -1;
			enemydogsr.flipX = true;
		}

	}

	void PlayerCheck()
	{
		AudioSource growl = this.GetComponent<AudioSource> ();

		Vector2 playerPos;
		playerPos.x = player.transform.position.x;
		playerPos.y = player.transform.position.y;

		if (lineofsight.OverlapPoint (playerPos)) 
		{
			isGrowling = true;

			if (!growl.isPlaying) 
			{
				growl.mute = false;
				growl.Play ();
				enemydoganim.SetBool ("isWait", true);
				this.GetComponent<Rigidbody> ().isKinematic = true;
			}

			if (player.GetComponentInChildren<Bark> ()._bark) 
			{
				enemydoganim.SetBool ("isWait", false);
				growl.mute = true;
				this.GetComponent<Rigidbody> ().isKinematic = false;

				Flee ();

			}
		}

		else
		{
			enemydoganim.SetBool ("isWait", false);
			isGrowling = false;
			growl.mute = true;
		}


	}

	void FoodCheck()
	{
		Transform itemContainer = GameObject.Find ("ItemContainer").GetComponent<Transform>();
		foreach (Transform item in itemContainer) 
		{
			Vector2 itemPos;
			itemPos.x = item.transform.position.x;
			itemPos.y = item.transform.position.y;


			if (lineofsight.OverlapPoint (itemPos)) 
			{
				Debug.Log ("Other dog sees object");
				GameObject itemID = item.gameObject;
			}
		}



	}


	/*void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log ("Collider triggered");

		if (other.tag == "item") 
		{
			GameObject Item = other.transform.parent.gameObject;
			bool edible = Item.GetComponent<ObjectClass>()._edible;
			if (edible = true) 
				
			{
				Debug.Log ("Autre chien a repéré nourriture !");
			}
		}
	} */

}
