using UnityEngine;
using System.Collections;

public class LilypadSpawn : MonoBehaviour {


	public int TimeDelay;
	private int CurrentTime;

	public int LeftLimit;
	public int RightLimit;

	public GameObject LilyPad;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameStateManager.Instance.gameState == GameState.GAME) {
		
			CurrentTime++;

			if(CurrentTime == TimeDelay)
			{
				CurrentTime = 0;
				Instantiate(LilyPad, new Vector3(Random.Range(LeftLimit, RightLimit), transform.position.y,0),transform.rotation);
			}

		}
	
	}
}
