using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreDistance : MonoBehaviour {

	public static int score;
	Text txt;

	// Use this for initialization
	void Awake()
	{
		QualitySettings.vSyncCount = 0;
		
		Application.targetFrameRate = 60;
	}

	void Start () 
	{
		txt = gameObject.GetComponent<Text>();
		txt.text = "Score : " + score;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameStateManager.Instance.gameState== GameState.GAME)
		{
			score+=1;
		}

		txt.text = "Score : " + score;
	}


}
