using UnityEngine;
using System.Collections;

public class frogMovement : MonoBehaviour 
{
	Vector3 temp;
	public float speed;
	float jumppowertemp;

	public GameObject arrow;
	public GameObject deathScreen;



	void Start () 
	{
		deathScreen.SetActive(false);
		jumppowertemp = 0;
		arrow.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameStateManager.Instance.gameState != GameState.PAUSED)
		{
			if(arrowMovement.frogJump == true)
			{
				jumppowertemp+=0.65f;
				Jump ();
			}
		}
	}

	void Jump()
	{
		if(arrowMovement.frogJump == true)
		{
			arrow.SetActive(false);
			//rotates the frog to match the arrows rotation
			transform.rotation = Quaternion.AngleAxis(arrowMovement.currentAngle+90, Vector3.forward);
			//move the frog foward
			transform.Translate(Vector3.right * speed);

			//moves the frog up then down
			if(jumppowertemp > arrowMovement.jumpPower)
			{
				transform.Translate(Vector3.forward * 5);
			}
			if(jumppowertemp < arrowMovement.jumpPower)
			{
				transform.Translate(Vector3.forward * -5);
			}
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Lilypad")
		{
			arrowMovement.moveArrow = true;
			arrowMovement.frogJump = false;
			jumppowertemp = 0;
			arrow.SetActive(true);
		}

		if(col.gameObject.tag == "Water")
		{
			deathScreen.SetActive(true);
			arrowMovement.frogJump = false;
			GameStateManager.Instance.SetGameState(GameState.DEATH);
		}
	}
}
