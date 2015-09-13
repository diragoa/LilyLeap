using UnityEngine;
using System.Collections;

public class frogMovement : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(arrowMovement.frogJump == true)
		{
			Jump ();
		}
	}

	void Jump()
	{
		transform.position = new Vector3(gameObject.transform.position.x+arrowMovement.jumpPower,gameObject.transform.position.y,gameObject.transform.position.z+arrowMovement.currentAngle);
		arrowMovement.frogJump = false;
	}
}
