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
	/// <summary>
	/// Making the initial score text with the current score
	/// </summary>
	void Start () 
	{
		txt = gameObject.GetComponent<Text>();
		txt.text = "Score : " + score;

	}
	
/// <summary>
/// Updating the score 
/// </summary>
	void Update () 
	{
		if(GameStateManager.Instance.gameState== GameState.GAME)
		{
			score+=1;
		}

		txt.text = "Score : " + score;
	}


}
