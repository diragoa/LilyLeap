using UnityEngine;
using System.Collections;

public class UIButtons : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {

	}
	/// <summary>
	/// Reloads the level setting the arrow movement true, frog cant jump, score back to zero, and the arrow set to 0 rotation. changes the state to the game menu
	/// </summary>
	public void Reset()
	{	
		GameAudioManager.Instance.PlayClick();
		GameStateManager.Instance.SetGameState(GameState.START);

		arrowMovement.moveArrow = true;
		arrowMovement.frogJump = false;
		arrowMovement.stopJumpTillCamStops = false;
		arrowMovement.isAtStart = true;
		scoreDistance.score=0;
		arrowMovement.currentAngle = 0;

		CameraTransition.instance.ResetCamera();
		Destroyer.instance.ResetScene();

		LilypadSpawn.instance.started = false;
	}
	/// <summary>
	/// if the game isnt pause, pause it, if it is pasued check if its in the start state or the game state and contie the game from that state
	/// </summary>
	public void Pause()
	{
		if(GameStateManager.Instance.gameState != GameState.PAUSED)
		{
			//GameAudioManager.Instance.PlayClick();
			GameStateManager.Instance.SetGameState(GameState.PAUSED);
		}

	}

	public void Play()
	{
	//	GameAudioManager.Instance.PlayClick();
		GameStateManager.Instance.SetGameState(GameState.START);
	}

	public void Store()
	{
	//	GameAudioManager.Instance.PlayClick();
		GameStateManager.Instance.SetGameState(GameState.STORE);
	}
	public void Menu()
	{
		Debug.Log("MenuButton");
	//	GameAudioManager.Instance.PlayClick();
		GameStateManager.Instance.SetGameState(GameState.MAIN_MENU);

		arrowMovement.moveArrow = true;
		arrowMovement.frogJump = false;
		arrowMovement.stopJumpTillCamStops = false;
		arrowMovement.isAtStart = true;
		scoreDistance.score=0;
		arrowMovement.currentAngle = 0;


		CameraTransition.instance.ResetCamera();
		Destroyer.instance.ResetScene();

		LilypadSpawn.instance.started = false;
	
	}

	public void Resume()
	{
		if(arrowMovement.isAtStart == true)
		{
		//	GameAudioManager.Instance.PlayClick();
			GameStateManager.Instance.SetGameState(GameState.START);
		}
		
		else
		{
			//GameAudioManager.Instance.PlayClick();
			GameStateManager.Instance.SetGameState(GameState.GAME);
		}
	}
}
