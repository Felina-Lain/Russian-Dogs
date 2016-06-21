using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

	public static List<Sprite> s_iconsL = new List<Sprite>();
	public List<Sprite> _iconsL = new List<Sprite>();

	public static List<string> s_scentL= new List<string>();
	public List<string> _scentL = new List<string>();

	// Use this for initialization
	void Start () {

		s_iconsL = _iconsL;
		s_scentL = _scentL;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
