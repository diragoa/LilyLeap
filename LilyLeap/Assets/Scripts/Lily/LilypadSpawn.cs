using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LilypadSpawn : MonoBehaviour {


	public int TimeDelay;
	private int CurrentTime;

	public int LeftLimit;
	public int RightLimit;

	public GameObject LilyPad;
	public GameObject LilyPadWithFly;

	private int FlyCountdown;
	private bool CountingDown = false;

	public Vector3[] startingPads;
	public bool started;
	public static LilypadSpawn instance = null;

	// Use this for initialization
	void Start () {
		if (LilypadSpawn.instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (GameStateManager.Instance.gameState == GameState.GAME) 
		{
		
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
						Destroyer.instance.padsInScene.Add ((GameObject)Instantiate(LilyPadWithFly, new Vector3(Random.Range(LeftLimit, RightLimit), transform.position.y,0),transform.rotation));
						CountingDown = false;
					}
					else
					{
						Destroyer.instance.padsInScene.Add ((GameObject)Instantiate(LilyPad, new Vector3(Random.Range(LeftLimit, RightLimit), transform.position.y,0),transform.rotation));
					}
				}
			}
		}
		if(GameStateManager.Instance.gameState == GameState.START && !started)
		{
			for (int i = 0; i<startingPads.Length;i++)
			{
				Destroyer.instance.padsInScene.Add((GameObject)Instantiate(LilyPad, startingPads[i],transform.rotation));

			}
			started = true;
		}
	}
}
