using UnityEngine;
using System.Collections;

public class CameraTransition : MonoBehaviour {


	public Transform MenuMarker;
	public Transform GameMarker;
	public Transform StoreMarker;

	public Transform CameraCanvas;

	public float Speed;

	public static CameraTransition instance = null;

	// Use this for initialization
	void Start () {
		if (CameraTransition.instance == null) {
			
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameStateManager.Instance.gameState == GameState.MAIN_MENU) 
		{
			//Debug.Log("Camera Transition to MainMenu");
			if(transform.position.x != MenuMarker.position.x)
			{
				transform.position = Vector3.Lerp(transform.position,MenuMarker.position,Speed);
				transform.position = new Vector3(transform.position.x,transform.position.y,-975);
			}

		} 
		else if (GameStateManager.Instance.gameState == GameState.START) 
		{
			//Debug.Log("Camera Transition to Start");
			if(transform.position.x != GameMarker.position.x)
			{
				transform.position = Vector3.Lerp(transform.position,GameMarker.position,Speed);
				transform.position = new Vector3(transform.position.x,transform.position.y,-975);
				if(transform.position.x >-2)
				{
					arrowMovement.stopJumpTillCamStops = true;
				}
				
			}

		} else if (GameStateManager.Instance.gameState == GameState.STORE) 
		{
			//Debug.Log("Camera Transition to Store");
			if(transform.position.x != StoreMarker.position.x)
			{
				transform.position = Vector3.Lerp(transform.position,StoreMarker.position,Speed);
				transform.position = new Vector3(transform.position.x,transform.position.y,-975);
			}
		}
	
	}

	public void ResetCamera()
	{
		CameraCanvas.position = new Vector3 (CameraCanvas.position.x, 0, CameraCanvas.position.z);
	}
}
