using UnityEngine;
using System.Collections;

public class SkinChange : MonoBehaviour {

	public Material[] Skins;



	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.GetComponent<MeshRenderer>().material = Skins[StoreManager.equippedIndex];
	
	}
}
