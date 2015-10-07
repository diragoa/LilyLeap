using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FBholder : MonoBehaviour 
{
	public GameObject isLoggedIn;
	public GameObject isNotLoggedIn;

	public string get_data;
	public string fbname;

	void Awake()
		{
			Facebook.Unity.FB.Init (SetInit, OnHideUnity);
		}

	private void SetInit()
	{
		Debug.Log ("FB INIT DONE.");

		if(Facebook.Unity.FB.IsLoggedIn)
		{
			Debug.Log("LOGGED IN");
			FBMenus(true);
		}
		else 
		{
			FBMenus(false);
		}
	}

	private void OnHideUnity(bool isGameShown)
	{
		if(!isGameShown)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
	}

	public void FBLogIn()
	{
		Facebook.Unity.FB.LogInWithReadPermissions (new List<string>(){ "email"},AuthCallback);
	}

	void AuthCallback(Facebook.Unity.IResult result)
	{
		if(Facebook.Unity.FB.IsLoggedIn)
		{
			FBMenus(true);
			Debug.Log("LOGGED IN WORKED");
		}
		else 
		{
			FBMenus(false);
			Debug.Log("LOGGIN FAILED");
		}
	}

	void FBMenus(bool loggedIn)
	{
		if(loggedIn)
		{
			isLoggedIn.SetActive(true);
			isNotLoggedIn.SetActive(false);


		}
		else
		{
			isLoggedIn.SetActive(false);
			isNotLoggedIn.SetActive(true);
		}
	}

	public void FaceBookInvite()
	{
		Facebook.Unity.FB.Mobile.AppInvite(new Uri("https://fb.me/933772966712842"));
	}
}
