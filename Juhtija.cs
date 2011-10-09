using UnityEngine;
using System.Collections;

public class Juhtija : MonoBehaviour {
	public float PooramisKiirus= 0.9f; 
	public int timer=0;
	public int nextFire=90;
	public float kiirtulesagedus=0.3f;
	public float accelerate = 0f;
public float steer = 0f; 
	public float hiirex=0f;
	public float hiirey=0f;
	private float k2ik=2f;
//public	GameObject tank;
	// Update is called once per frame
	/*void Start()
	{
		if(GameObject.FindWithTag("CV-90"))
		{
		tank=GameObject.FindWithTag("CV-90");
		}
	}
	*/
	void FixedUpdate () {
		timer++;
		if(GameObject.FindWithTag("Test-kere"))
			{//edasisõitmine
	accelerate = 0f;
	steer = 0f; 
	accelerate = Input.GetAxis("Vertical"); //4 
	steer = Input.GetAxis("Horizontal"); //4 
				//hiirex=Input.GetAxis ("Mouse X");
				//hiirey=Input.GetAxis ("Mouse Y");
				GameObject tank=GameObject.FindWithTag("Test-kere");
	if(accelerate!=0||steer!=0)
	{
	float[] liikumisandmed = new float[2];
		//Debug.Log("kiirendus"+accelerate);
//		Debug.Log("pööramine"+steer);
	liikumisandmed[0]=accelerate;
	liikumisandmed[1]=steer;
	//GameObject tank=GameObject.FindWithTag("CV-90");
	//GameObject.FindWithTag("CV-90").RoomikuJuhtija("UpdateWheels"(accelerate,steer)); //5 
	tank.gameObject.SendMessageUpwards("UpdateWheels",liikumisandmed);
				
	}
//}

	//	if(GameObject.FindWithTag("CV-90"))
		//{
	//			if(hiirex!=0||hiirey!=0){
//	float[] pooramisandmed = new float[2];//tornipööramine.
		//	{
//	pooramisandmed[0]+=hiirex;
//	pooramisandmed[1]+=hiirey;
	//pooramisandmed[0]= Mathf.Clamp (pooramisandmed[0], -3.0f, 3.0f);
//	pooramisandmed[1]= Mathf.Clamp (pooramisandmed[1], -5.0f, 10.0f);
		//	GameObject tank=GameObject.FindWithTag("CV-90");
	//GameObject.FindWithTag("CV-90").RoomikuJuhtija("UpdateWheels"(accelerate,steer)); //5 
	//tank.gameObject.BroadcastMessage("PooraTorni",pooramisandmed);
		//	}
		}
	}


void Update() {
        if (Input.GetButton("Fire1") && timer > nextFire) {
			if(GameObject.FindWithTag("Test-kere"))
				{
					GameObject tank=GameObject.FindWithTag("Test-kere");
					tank.gameObject.BroadcastMessage("lask");
					timer=0;
				}
		}
			;
		if (Input.GetButton("Fire2") && timer > nextFire)
		{
			if(GameObject.FindWithTag("Test-kere"))
			{
				GameObject tank=GameObject.FindWithTag("Test-kere");
			tank.gameObject.BroadcastMessage("laskmine",kiirtulesagedus);
				timer=0;
			}
		}
		if (Input.GetButtonDown("k2ikyles"))
		{
			if(GameObject.FindWithTag("Test-kere"))
			{
				if (k2ik<2)
				{
				GameObject tank=GameObject.FindWithTag("Test-kere");
				k2ik=k2ik+1;
			tank.gameObject.BroadcastMessage("VahetaK2iku",k2ik);
				}
			}
		}
		if (Input.GetButtonDown("k2ikalla"))
		{
			if(GameObject.FindWithTag("Test-kere"))
			{
				if (k2ik!=1)
				{
				GameObject tank=GameObject.FindWithTag("Test-kere");
				k2ik=k2ik-1;
			tank.gameObject.BroadcastMessage("VahetaK2iku",k2ik);
				}
			}
		}
	}

}
