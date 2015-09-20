using UnityEngine;
using System.Collections;

public class restButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Rest()
	{	
		scoreDistance.score=0;
		arrowMovement.currentAngle = 0;
		GameStateManager.Instance.SetGameState(GameState.DEATH);
		Application.LoadLevel(0);
	}
}
