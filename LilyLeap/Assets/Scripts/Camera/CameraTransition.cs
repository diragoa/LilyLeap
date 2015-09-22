using UnityEngine;
using System.Collections;

public class CameraTransition : MonoBehaviour {


	public Transform MenuMarker;
	public Transform GameMarker;
	public Transform StoreMarker;

	public float Speed;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameStateManager.Instance.gameState == GameState.MAIN_MENU) 
		{
			if(transform.position.x != MenuMarker.position.x)
			{
				transform.position = Vector3.Lerp(transform.position,MenuMarker.position,Speed);
				transform.position = new Vector3(transform.position.x,transform.position.y,-975);
			}
		} else if (GameStateManager.Instance.gameState == GameState.START) 
		{
			if(transform.position.x != GameMarker.position.x)
			{
				transform.position = Vector3.Lerp(transform.position,GameMarker.position,Speed);
				transform.position = new Vector3(transform.position.x,transform.position.y,-975);
				if(transform.position.x < 1)
				{
					arrowMovement.stopJumpTillCamStops = true;
				}
				
			}

		} else if (GameStateManager.Instance.gameState == GameState.STORE) 
		{
			if(transform.position.x != StoreMarker.position.x)
			{
				transform.position = Vector3.Lerp(transform.position,StoreMarker.position,Speed);
				transform.position = new Vector3(transform.position.x,transform.position.y,-975);
			}
		}
	
	}
}
