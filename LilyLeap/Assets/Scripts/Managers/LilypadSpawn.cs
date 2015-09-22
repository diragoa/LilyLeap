using UnityEngine;
using System.Collections;

public class LilypadSpawn : MonoBehaviour {


	public int TimeDelay;
	private int CurrentTime;

	public int LeftLimit;
	public int RightLimit;

	public GameObject LilyPad;
	public GameObject LilyPadWithFly;

	private int FlyCountdown;
	private bool CountingDown = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameStateManager.Instance.gameState == GameState.GAME) {
		
			CurrentTime++;



			if(CountingDown == false)
			{
				FlyCountdown = Random.Range(1,7);
				CountingDown = true;
			}
			if(CurrentTime == TimeDelay)
			{
				CurrentTime = 0;
				if(CountingDown == true)
				{
					FlyCountdown--;
					if(FlyCountdown == 0)
					{
						Instantiate(LilyPadWithFly, new Vector3(Random.Range(LeftLimit, RightLimit), transform.position.y,0),transform.rotation);
						CountingDown = false;
					}
					else
					{
						Instantiate(LilyPad, new Vector3(Random.Range(LeftLimit, RightLimit), transform.position.y,0),transform.rotation);
					}
				}
			}


		}
	
	}
}
