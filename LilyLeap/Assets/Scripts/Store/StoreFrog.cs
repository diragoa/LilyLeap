using UnityEngine;
using System.Collections;

public class StoreFrog : MonoBehaviour {

	private bool Unlocked;

	public GameObject buyButton;
	public GameObject equipButton;

	// Use this for initialization
	void Start () {
	
		if(StoreManager.Unlocked[StoreManager.storeIndex] == true)
		{
			Unlocked = true;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	

		if(StoreManager.Unlocked[StoreManager.storeIndex] == true)
		{
			Unlocked = true;
		}


		if(Unlocked == false)
		{
			buyButton.SetActive(true);
			equipButton.SetActive(false);
		}
		else if(Unlocked == true)
		{
			buyButton.SetActive(false);
			equipButton.SetActive(true);
		}

	}
}
