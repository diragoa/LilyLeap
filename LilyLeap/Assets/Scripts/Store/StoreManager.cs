using UnityEngine;
using System.Collections;

public class StoreManager : MonoBehaviour {

	public static GameObject[] Frogs;
	public static bool[] Unlocked;

	public static int storeIndex;
	public static int equippedIndex;

	// Use this for initialization
	void Start () {
		storeIndex = 0;
		equippedIndex = 0;
		Frogs[storeIndex].SetActive(true);

	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	static void FrogChange(int change)
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

	public static void StoreChange(int change)
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
