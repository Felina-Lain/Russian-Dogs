using UnityEngine;
using System.Collections;

public class ScentDetect : MonoBehaviour {

	public Collider2D selfcollider;

	// Use this for initialization
	void Start () 
	{
		selfcollider = this.GetComponentInChildren<Collider2D>();


	}
	
	// Update is called once per frame
	void Update () 
	{
		//detecting overlap between object smell collider and player smell collider
		GameObject player = GameObject.FindWithTag ("Player");
		Vector2 playerPos;
		playerPos.x = player.transform.position.x;
		playerPos.y = player.transform.position.y;

		if (selfcollider.OverlapPoint (playerPos)) 
			{
			Debug.Log ("Smelling " + this.name);
		} 
		else 
		{
			Debug.Log ("Not smelling " + this.name);
		}

	}
}
