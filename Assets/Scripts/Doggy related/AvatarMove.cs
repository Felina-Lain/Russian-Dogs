using UnityEngine;
using System.Collections;

public class AvatarMove : MonoBehaviour {
	
	public static bool IsJumping{ get; private set;}

	public float Speed = 0f;
	public float MaxJumpTime = 2f;
	public float JumpForce;
	private float move = 0f;
	private float JumpTime = 0f;
	private bool CanJump;

	void Start () {
		JumpTime  = MaxJumpTime;
	}


	void Update ()
	{
		if (!CanJump)
			JumpTime  -= Time.deltaTime;
		if (JumpTime <= 0)
		{
			CanJump = true;
			JumpTime  = MaxJumpTime;
		}

		IsJumping = !CanJump;
	}

	void FixedUpdate () {
		move = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody>().velocity = new Vector3 (move * Speed, GetComponent<Rigidbody>().velocity.y);
		if (Input.GetKey (KeyCode.UpArrow)  && CanJump)
		{
			GetComponent<Rigidbody>().AddForce (new Vector3 (GetComponent<Rigidbody>().velocity.x,JumpForce));
			CanJump = false;
			JumpTime  = MaxJumpTime;

/*			//ajuste le point de transport des objets
			if (Manager.player_direction == "Right") {
				GameObject carrypoint = GameObject.Find ("CarryPoint");
				Vector3 carryV = carrypoint.transform.position;
				carryV.x = (carryV + 1.50f);
				carryV.y = (carryV + 0.50f);
				carrypoint.transform.position = carryV;
			} 
			else 
			{
				GameObject carrypoint = GameObject.Find ("CarryPoint");
				Vector3 carryV = carrypoint.transform.position;
				carryV.x = (carryV - 1.50f);
				carryV.y = (carryV - 0.50f);
				carrypoint.transform.position = carryV;
			} */
		} 


	}
}