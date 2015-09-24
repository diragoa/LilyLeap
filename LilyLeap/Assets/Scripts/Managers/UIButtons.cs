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
	/// <summary>
	/// Reloads the level setting the arrow movement true, frog cant jump, score back to zero, and the arrow set to 0 rotation. changes the state to the game menu
	/// </summary>
	public void Reset()
	{	
		arrowMovement.moveArrow = true;
		arrowMovement.frogJump = false;
		scoreDistance.score=0;
		arrowMovement.currentAngle = 0;
		GameStateManager.Instance.SetGameState(GameState.MAIN_MENU);
		Application.LoadLevel(0);
	}
	/// <summary>
	/// if the game isnt pause, pause it, if it is pasued check if its in the start state or the game state and contie the game from that state
	/// </summary>
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

	public void Play()
	{
		GameStateManager.Instance.SetGameState(GameState.START);
	}

	public void Store()
	{
		GameStateManager.Instance.SetGameState(GameState.STORE);
	}
	public void Menu()
	{
		GameStateManager.Instance.SetGameState(GameState.MAIN_MENU);
	}
}
