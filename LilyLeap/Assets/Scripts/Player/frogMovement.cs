using UnityEngine;
using System.Collections;

public class frogMovement : MonoBehaviour 
{
	public float speed;
	float jumppowertemp;

	public GameObject arrow;
	public GameObject deathScreen;


	/// <summary>
	/// Smaking sure the death screen is not showing, starting the jump power back to zero and making the arrow roate
	/// </summary>
	void Start () 
	{
		deathScreen.SetActive(false);
		jumppowertemp = 0;
		arrow.SetActive(true);
	}
	
/// <summary>
/// Uif the game isnt pause, set the jump power to a small number and call the jump function
	/// </summary>
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
	/// <summary>
	/// roatates the frog in the direction of the arrow and jumps 
	/// </summary>
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
	/// <summary>
	/// 	If the frog hits the lilypad bring the arrow back and allow the frog to jump again, if the frog hits the water then show the death screen and change the sate to death
	/// </summary>

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
