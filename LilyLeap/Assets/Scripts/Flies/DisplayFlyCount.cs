﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayFlyCount : MonoBehaviour {

	Text txt;


	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "Flies: " + FlyCount.instance.Flies;
	
	}
}
