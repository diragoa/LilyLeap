using UnityEngine;
using System.Collections;
/// <summary>
/// Game State manager to deal with all states of the game.
/// Set the game state with "GameStateManager.Instance.SetGameState (GameState.GAME);"
/// Get the game state with "GameStateManager.Instance.gameState;"
/// </summary>



public enum GameState {MAIN_MENU, START, GAME, DEATH, STORE, PAUSED }


public class GameStateManager : MonoBehaviour {

	public static GameStateManager instance = null;
	public GameState gameState{ get; private set;}
	public AudioSource click;

	//Allows the getting of the gamestate variable
	public static GameStateManager Instance {
		get{
			return GameStateManager.instance;
		}
	}

	void Awake()
	{
		if (GameStateManager.instance == null) {
			
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	public void SetGameState(GameState state){
		this.gameState = state;
	}


	public void OnApplicationQuit()
	{
		GameStateManager.instance = null;
	}
}
