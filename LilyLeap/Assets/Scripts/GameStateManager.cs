using UnityEngine;
using System.Collections;
/// <summary>
/// Game State manager to deal with all states of the game.
/// Set the game state with "GameStateManager.Instance.SetGameState (GameState.GAME);"
/// Get the game state with "GameStateManager.Instance.gameState;"
/// </summary>



public enum GameState {MAIN_MENU, START, GAME, DEATH, STORE }


public class GameStateManager : MonoBehaviour {

	protected GameStateManager(){}
	private static GameStateManager instance = null;
	public GameState gameState{ get; private set;}

	//Allows the getting of the gamestate variable
	public static GameStateManager Instance {
		get{
			if(GameStateManager.instance == null){
				DontDestroyOnLoad(GameStateManager.instance);
				GameStateManager.instance = new GameStateManager();
			}
			return GameStateManager.instance;
		}
	}

	public void SetGameState(GameState state){
		this.gameState = state;
	}


	public void OnApplicationQuit()
	{
		GameStateManager.instance = null;
	}
}
