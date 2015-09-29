using UnityEngine;
using System.Collections;

public class FlyCount : MonoBehaviour {


	public static FlyCount instance = null;
	
	public static int Flies;
	
	// Use this for initialization
	void Start () {
		if (FlyCount.instance == null) {
			
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
		
	}



	
	// Update is called once per frame
	void Update () {
	
	}
}
