using UnityEngine;
using System.Collections;

public class LilyPad : MonoBehaviour {

	private Vector3 Scale;


	// Use this for initialization
	void Start () {
		Scale = transform.localScale;
		transform.localScale = new Vector3 (0,0,1);
	
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.localScale.x < Scale.x)
		{
			transform.localScale += new Vector3 (0.4f,0.4f);
		}
	
	}
}
