using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class arrowMovement : MonoBehaviour 
{
	public static float currentAngle;
	public float speedOfArrow;
	public static float jumpPower;

	Vector3 tempAngle;

	public Slider arrowPower;

	public static bool moveArrow;
	public static bool frogJump;

	void Start () 
	{
		//setting the temp angle equal to the object's angle
		tempAngle = gameObject.transform.localEulerAngles;

		moveArrow = true;

		arrowPower.value = 0;
	}
	

	void Update () 
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
				//stops the arrow and starts the slider value to one
				switch(touch.phase)
				{
				case TouchPhase.Began:
					moveArrow = false;
					arrowPower.value = 1;
					break;

				//while holding your finger in placw the value of the slider will increase
				case TouchPhase.Stationary:
					arrowPower.value+=1;
					break;

				//while moving your fingerthe value of the slider will increase
				case TouchPhase.Moved:
					arrowPower.value+=1;
					break;

				//releasing will set jump power equal to the value
				case TouchPhase.Ended:
					jumpPower = arrowPower.value;
					//this will moved moved to frog controlls and set to true when the frog hits the lilypad
					//moveArrow = true;
					frogJump = true;
					break;

				}
			}
		}

	}

	void ArrowMovement()
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
		//setting the z axis of the temp angle to the current angle and then setting the arrows angle equal to the temps
		tempAngle.z = currentAngle;
		gameObject.transform.localEulerAngles = tempAngle;
	}
}

