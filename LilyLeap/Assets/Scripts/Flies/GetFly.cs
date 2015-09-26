using UnityEngine;
using System.Collections;

public class GetFly : MonoBehaviour {

	public static int Flies;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Destroy(gameObject);
			Flies += 1;
			save.saver.Save();
		}
	}
}
