using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoreManager : MonoBehaviour {

	public static StoreManager instance = null;

	public  GameObject[] Frogs;
	public static bool[] Unlocked;
	

	public static int storeIndex;
	public static int equippedIndex;

	// Use this for initialization
	void Awake () {

		if (StoreManager.instance == null) {
			
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
		Unlocked = new bool[Frogs.Length];
		storeIndex = 0;
		equippedIndex = 0;
		Unlocked[0] = true;
		for(int i = 1; i<Unlocked.Length; i++)
		{
			Unlocked[i] = false;
		}

		Frogs[storeIndex].SetActive(true);

	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FrogChange(int change)
	{
		int tempIndex;
		tempIndex = storeIndex;
		tempIndex -= change;
		if(tempIndex == -1)
		{
			tempIndex = Frogs.Length - 1;
		}
		
		if(tempIndex == Frogs.Length)
		{
			tempIndex = 0;
		}

		Frogs[tempIndex].SetActive(false);
		Frogs[storeIndex].SetActive(true);

	}

	public void StoreChange(int change)
	{
		storeIndex += change;
		if(storeIndex == -1)
		{
			storeIndex = Frogs.Length - 1;
		}

		if(storeIndex == Frogs.Length)
		{
			storeIndex = 0;
		}
		FrogChange (change);
	}


}
