using UnityEngine;
using System.Collections;

public class frogMovement : MonoBehaviour 
{
	public float speed;
	float jumppowertemp;

	public GameObject arrow;
	public GameObject deathScreen;
	public GameObject pauseMenu;
	public GameObject pauseButton;
	public GameObject faceBookShareButton;
	private Vector3 startPos;
	/// <summary>
	/// Smaking sure the death screen is not showing, starting the jump power back to zero and making the arrow roate
	/// </summary>

	void Awake()
	{
		save.saver.Load();
	}
	void Start () 
	{
		faceBookShareButton.SetActive(false);
		deathScreen.SetActive(false);
		arrow.SetActive(true);
		startPos = gameObject.transform.position;
	}
	
/// <summary>
/// Uif the game isnt pause, set the jump power to a small number and call the jump function
	/// </summary>
	void Update () 
	{
		if(GameStateManager.Instance.gameState == GameState.DEATH)
		{
			pauseButton.SetActive(false);
		}
		else
		{
			pauseButton.SetActive(true);
		}
		if(GameStateManager.Instance.gameState != GameState.PAUSED)
		{
			pauseMenu.SetActive(false);

			if(arrowMovement.frogJump == true)
			{
				jumppowertemp+=0.65f;
				Jump ();
			}
			else
			{
				jumppowertemp = 0;
			}
		}

		if(GameStateManager.Instance.gameState == GameState.PAUSED)
		{
			pauseMenu.SetActive(true);
		}
		if(GameStateManager.Instance.gameState == GameState.START)
		{
			GameAudioManager.Instance.BackgroundMusicPlay();
			transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
			jumppowertemp = 0;
			deathScreen.SetActive(false);
			faceBookShareButton.SetActive(false);
			gameObject.transform.position = new Vector3 (startPos.x,startPos.y,startPos.z);
			arrow.SetActive(true);
		}
		if(GameStateManager.Instance.gameState == GameState.MAIN_MENU)
		{
			transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
			deathScreen.SetActive(false);
			faceBookShareButton.SetActive(false);
			gameObject.transform.position = new Vector3 (startPos.x,startPos.y,startPos.z);
			arrow.SetActive(true);
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
			save.saver.Save();
			deathScreen.SetActive(true);
			faceBookShareButton.SetActive(true);
			arrowMovement.frogJump = false;
			GameStateManager.Instance.SetGameState(GameState.DEATH);
		}
	}
}
