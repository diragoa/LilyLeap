using UnityEngine;
using System.Collections;

public class UIButtons : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reset()
	{	
		arrowMovement.moveArrow = true;
		arrowMovement.frogJump = false;
		scoreDistance.score=0;
		arrowMovement.currentAngle = 0;
		GameStateManager.Instance.SetGameState(GameState.START);
		Application.LoadLevel(0);
	}

	public void Pause()
	{
		if(GameStateManager.Instance.gameState != GameState.PAUSED)
		{
			GameStateManager.Instance.SetGameState(GameState.PAUSED);
		}

		else if(GameStateManager.Instance.gameState == GameState.PAUSED)
		{
			if(arrowMovement.isAtStart == true)
			{
				GameStateManager.Instance.SetGameState(GameState.START);
			}
		
			else
			{
				GameStateManager.Instance.SetGameState(GameState.GAME);
			}
		}
	

	}
}
