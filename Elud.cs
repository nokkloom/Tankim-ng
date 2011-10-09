using UnityEngine;
using System.Collections;

public class Elud : MonoBehaviour {
public float minuelud=100f;
public float taiselud=100f;
public float EluBar;
public GameObject kaamera;
//public bool elan =true;
	//märkus endale: miskipärast toimub otsustamine kas asi lendab taagasi spawni mürsu juures. tont olukord.
	void Start() {
		EluBar = Screen.width / 2;
		
	}
	
	void SaaAia(float aia)
	{
		
		minuelud=minuelud-aia;
		Debug.Log("aia");
		EluBar = (Screen.width / 2) * (minuelud / taiselud);
	if(minuelud<1)
	{	
			/*ConnectionGUI2 other;
//other = kaamera.gameObject.GetComponent("ConnectionGUI2") as ConnectionGUI2;
			other.olemas=false;*/
kaamera.gameObject.SendMessage("Kadus");
Destroy (gameObject);
	}
		//GetComponentInChildren<Soomusetugevus>().alleselud=minuelud;
		
		
//bool asi= kaamera.gameObject.GetComponent(ConnectionGUI2);
//other2.Player=tankid[1];
//ConnectionGUI2 myTransform = GetComponent("ConnectionGUI2");
		
	}
	void EludTagasi()
	{
		//peaks olema jäänuk, ei tohiks midagi teha.
	minuelud=taiselud;
	}
	
	void OnGUI() {
			GUI.Box(new Rect(10, Screen.height - 30, EluBar, 20), minuelud + "/" + taiselud);
	}	

}

					