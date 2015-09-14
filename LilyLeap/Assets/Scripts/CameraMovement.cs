using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public int MoveSpeed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameStateManager.Instance.gameState == GameState.GAME) {
			transform.Translate(0,MoveSpeed,0);
		} 
		if (GameStateManager.Instance.gameState == GameState.START) {
			transform.position = new Vector3 (0,0,-975);
		}
	}
}
