using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvatarAnimations : MonoBehaviour 
{
	public GameObject PlayerSprite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		SpriteRenderer playersr = PlayerSprite.GetComponent<SpriteRenderer> ();

		if (Manager.player_direction == "left") 
		{

			playersr.flipX = true;

		} 
		else 
		{
			playersr.flipX = false;
		}
	
	}
}
