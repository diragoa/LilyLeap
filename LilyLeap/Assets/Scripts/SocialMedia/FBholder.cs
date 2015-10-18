using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FBholder : MonoBehaviour 
{
	public GameObject isLoggedIn;
	public GameObject isNotLoggedIn;

	private const string FACEBOOK_APP_ID = "933772966712842";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";

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
		Facebook.Unity.FB.LogInWithReadPermissions (new List<string>(){ "email","public_profile"," user_friends"},AuthCallback);
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

	public void FaceBookShare(string linkParameter, string nameParameter, string captionParameter, string descriptionParameter, string pictureParameter,string redirectParameter)
	{


		Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
		                     "&link=" + WWW.EscapeURL(linkParameter) +
		                     "&name=" + WWW.EscapeURL(nameParameter) +
		                     "&caption=" + WWW.EscapeURL(captionParameter) + 
		                     "&description=" + WWW.EscapeURL(descriptionParameter) + 
		                     "&picture=" + WWW.EscapeURL(pictureParameter) + 
		                     "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
	}
	public void FaceBookShareButton()
	{
		/*FaceBookShare("https://www.facebook.com/lilyleap?fref=nf",
		              "I just went " + scoreDistance.score + "!",
		              "Come check out LilyLeap!",
		             	"Think you can beat my score?" ,
		              "https://www.facebook.com/lilyleap/photos/pb.451905291659975.-2207520000.1445194013./455864371264067/?type=3&theater" ,
		              "https://www.facebook.com/");*/

		Application.OpenURL("http://www.facebook.com/dialog/feed?app_id=933772966712842&link=https://www.facebook.com/lilyleap?fref=nf&name=I just went " + scoreDistance.score +"&caption=Come check out LilyLeap!&description=Think you can beat my score?&picture=https://www.facebook.com/lilyleap/photos/pb.451905291659975.-2207520000.1445194013./455864371264067/?type=3&theater&redirect_uri=https://www.facebook.com/");
	}

}
