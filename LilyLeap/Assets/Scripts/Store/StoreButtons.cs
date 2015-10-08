using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreButtons : MonoBehaviour {

	public bool leftArrow;
	public bool buy;
	public bool equip;


	public int buyPrice;
	private Text buyText;


	// Use this for initialization
	void Start () {

		if(buy == true)
		{
			buyText = gameObject.GetComponentInChildren<Text>();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(buy == true)
		{
			buyText.text = buyPrice + " flies";
		}
	
	}

	public void LeftRight()
	{
		if(leftArrow == true)
		{
			GameAudioManager.Instance.PlayClick();
			StoreManager.instance.StoreChange(-1);
		}
		else if (leftArrow == false)
		{
			GameAudioManager.Instance.PlayClick();
			StoreManager.instance.StoreChange(1);
		}
	}
	public void Buy()
	{
		FlyCount.Flies -= buyPrice;
		StoreManager.Unlocked [StoreManager.storeIndex] = true;
		save.saver.Save();
	}

	public void Equip()
	{
		StoreManager.equippedIndex = StoreManager.storeIndex;
		save.saver.Save();
	}
}
