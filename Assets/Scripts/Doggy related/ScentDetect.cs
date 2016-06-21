using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScentDetect : MonoBehaviour {

	public Collider2D selfcollider;

	public bool isSmelling;

	public GameObject trail;
	public GameObject trailContainer;
	public Color trailColor;


	float trailTimer;

	// Use this for initialization
	void Start () 
	{
		selfcollider = this.GetComponentInChildren<Collider2D>();
		trail = Resources.Load<GameObject> ("ScentTrail");
		trailContainer = GameObject.Find ("ScentTrailContainer");
			

	}
	
	// Update is called once per frame
	void Update ()
	{
		//detecting overlap between object smell collider and player smell collider
		GameObject player = GameObject.FindWithTag ("Player");
		Vector2 playerPos;
		playerPos.x = player.transform.position.x;
		playerPos.y = player.transform.position.y;

		Vector2 selfPos;
		selfPos.x = this.transform.position.x;
		selfPos.y = this.transform.position.y;

		if (selfcollider.OverlapPoint (playerPos)) {
			isSmelling = true;
		} else {
			isSmelling = false;
		}

		//smell trail
		if (isSmelling) {
			trailTimer = trailTimer + Time.deltaTime;

			if (trailTimer >= 0.3f) {
				trailTimer = 0;
				GameObject t = Instantiate (trail);
				Vector3 midPoint;
				midPoint.x = Mathf.Lerp (selfPos.x, playerPos.x, 0.5f);
				midPoint.y = Mathf.Lerp (selfPos.y, playerPos.y, 0.5f);
				midPoint.z = 0;

				t.name = ("Trail" + this.name);
				t.transform.position = midPoint;
				t.transform.parent = trailContainer.transform;

				ParticleSystem parentparticles = this.GetComponent<ParticleSystem> ();
				ParticleSystem trailparticles = t.GetComponent<ParticleSystem> ();

				var colP = parentparticles.startColor;
				var colT = trailparticles.startColor;



				trailparticles.startColor = colP; 

			
			}
			


		}

		if (!isSmelling) {
			Destroy (GameObject.Find ("Trail" + this.name));

		}

		if (Mathf.RoundToInt(playerPos.x) == Mathf.RoundToInt(selfPos.x)) 
		{
			Destroy (GameObject.Find ("Trail" + this.name));
		}
			
	}
}
