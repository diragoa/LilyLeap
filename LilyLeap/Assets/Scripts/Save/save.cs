using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class save : MonoBehaviour 
{
	public static save saver;
	private int flies;


	void Awake()
	{
		if(saver==null)
		{
			DontDestroyOnLoad(gameObject);
			saver = this;
		}
		else if(saver!=null)
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.frog");
		
		PlayerData data = new PlayerData();
		
		data.Flies = GetFly.Flies;
		
		
		bf.Serialize(file,data);
		file.Close();
		
	}
	
	public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/playerInfo.frog"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.frog",FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close ();
			
			GetFly.Flies = data.Flies;

		}
	}
	
	[Serializable]
	class PlayerData
	{
		public int Flies;
		
	}
}
