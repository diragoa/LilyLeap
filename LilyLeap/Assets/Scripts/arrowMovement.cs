using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class arrowMovement : MonoBehaviour 
{
	public static float currentAngle;
	public float speedOfArrow;
	public static float jumpPower;

	public Slider arrowPower;

	public static bool moveArrow;
	public static bool frogJump;

	public static Vector3 tempangle;

	public static bool isAtStart;

	void Start () 
	{
		moveArrow = true;

		arrowPower.value = 0;

		isAtStart = true;

	}
	

	void Update () 
	{
		if(GameStateManager.Instance.gameState == GameState.START ||GameStateManager.Instance.gameState == GameState.GAME)
		{

			if(moveArrow == true)
			{
				ArrowMovement();
			}
			if(frogJump == false)
				{
					if(Input.touchCount > 0)
					{

						var touch = Input.GetTouch(0);

						if(touch.position.y < Screen.height-150)
						{
						//stops the arrow and starts the slider value to one
						switch(touch.phase)
						{
						case TouchPhase.Began:
							moveArrow = false;
							arrowPower.value = 0.5f;

							break;

						//while holding your finger in placw the value of the slider will increase
						case TouchPhase.Stationary:
							arrowPower.value+=0.5f;
							break;

						//while moving your fingerthe value of the slider will increase
						case TouchPhase.Moved:
							arrowPower.value+=0.5f;
							break;

						//releasing will set jump power equal to the value
						case TouchPhase.Ended:
							jumpPower = arrowPower.value;
							frogJump = true;
								if(GameStateManager.Instance.gameState== GameState.START)
								{
									GameStateManager.Instance.SetGameState(GameState.GAME);
									isAtStart = false;
								}
							break;
						}
					}
				}
			}
		}

	}

	void ArrowMovement()
	{

		if(GameStateManager.Instance.gameState == GameState.START ||GameStateManager.Instance.gameState == GameState.GAME)
		{
		//increating the angle by the speed variable
			currentAngle += speedOfArrow;
			arrowPower.value = 0;
			if(currentAngle>50)
			{
				speedOfArrow*=-1;
			}
			if(currentAngle<-50)
			{
				speedOfArrow*=-1;
			}

			transform.rotation = Quaternion.AngleAxis(currentAngle, Vector3.forward);
			}

	}
}

