// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Myrsk2 : MonoBehaviour {
/*
Right, well what this script basically does is everything to do with the tank shell.
It gives it a life timer, explosion, sets the explosion power, and the radius if 
maximum effect of the explosion and more. It is put on the shell prefab, so no worries
about adding all this code to the shoot script, because it is done here.
*/

public float lifeTimer = 0.0f; //The timer of life for this projectile.
public float lifeTimerMax = 12.0f; //The max amount of time that this shell will live.
public float explosionRadius = 5.0f; //The radius of our collision.
public float explosionPower = 350.0f;  //The amount of explosion shall have.
public float l2bivus = 40.0f;//mürsu läbistus võime
public float kahjustus = 40.0f;//Näitab palju on keskmine kahju mida myrsk teeb, kui on soomus läbistanud.
public float soomuselemojuvjoud = 0.0f;
public	float soomusetugevus=0.0f;
public	float aia=0.0f;
public float elukesed=0.0f;
public GameObject explosion; //The GameObject that will replace this wonderful shell of destruction.
float porkekiirus=0.0f;
//The less used FixedUpdate() function. Everything to do with physics should go in this function simply because this way they will be updated every frame that is and that should be.
void  FixedUpdate (){
	//The line below sets the variables thisPosition to the forward direction of the projectile.
	Vector3 thisDirection = transform.position + transform.TransformDirection(Vector3.forward); 
	rigidbody.AddForceAtPosition(Vector3.up * -9.81f, thisDirection); //This line, basically states that it will add a force at the position of the variable thisPosition.
}
//The Update() function I like to keep explaining.
void  Update (){
	lifeTimer += 1 * Time.deltaTime; //Adds one to the lifeTimer variable every second.
	//If lifeTimer is greater than or equal to lifeTimerMax.
	if(lifeTimer >= lifeTimerMax) {
		Destroy (gameObject); //This is rather self explaing. It states that this object will be destroyed.
	}
}

//The OnCollisionEnter() function. Very useful indeed. When this object enters a collision, the stuff inside this function happens.
void OnCollisionEnter(Collision collision) {
	if(GameObject.FindWithTag("Test-kere"))
	{
		if((collision.gameObject.tag == "Untagged")||(collision.gameObject.tag =="Test-kere"))
	{	
ContactPoint contact = collision.contacts[0];
Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
	porkekiirus=collision.relativeVelocity.magnitude;
	explosionThing(collision,porkekiirus); //Go to the explosionThing() function.
	Vector3 pos = contact.point;
	Instantiate(explosion, pos, rot); //Instantiate the explosion GameObject, at the position of this projectile, and rotation.
	Destroy (gameObject); //Destroy this GameObject.
}
}
}

//Our own function that lets us make boom (lets us create an explosion).
void  explosionThing (Collision collision, float porkekiirus){	
	//Collider[] colliders = collision.contacts[0];
	if (collision.gameObject.tag == "Test-kere"){
	//Collider[] colliders = Physics.OverlapSphere (transform.position, explosionRadius); //Sets a collider sphere variable.
	//For each new thing the hit var, that we define in the function, that the explosionRadius collides with.
	//foreach(var hit in colliders) { 	
		
float kalle = Quaternion.Angle(transform.rotation, collision.collider.transform.rotation);
//float kalle = 30f;	
		//If the thing we hit is a rigidbody.
			if (collision.rigidbody)  
				{ 
			collision.rigidbody.AddExplosionForce(explosionPower, transform.position, explosionRadius); //Add an explosion force that affects all rigidbody's.
			//Destroy(hit.gameObject);
			} 
	//Elud proov = hit.gameObject.GetComponent <Elud>();
			if(collision.collider.gameObject.GetComponent <Soomusetugevus>()==true)
			{
		/*	float elud=hit.collider.gameObject.GetComponent <Elud>().minuelud;
			
			if (elud>1)
			{
				if(kalle<60||kalle>300)
				{
				float soomuselemojuvjoud=Random.Range(0.8f,1.2f)*kahjustus*(90-kalle)/100*porkekiirus/20;
				float soomusetugevus=hit.collider.gameObject.GetComponent <Soomusetugevus>().soomusetugevus;
					if(soomuselemojuvjoud>soomusetugevus)
					{
				float tegelikkahjustus=Random.Range(0.8f,1.2f)*kahjustus*(90-kalle)/100*porkekiirus/20;
				hit.collider.gameObject.GetComponent <Elud>().minuelud=elud-tegelikkahjustus;
				elud=elud-tegelikkahjustus;
					}
			if(elud<2)
			{
				Destroy(hit.gameObject);
			}
			}
			}*/
	//Elud proov = hit.gameObject.GetComponent <Elud>();
			Debug.Log("midagi toimub");
			Debug.Log(kalle);
				if(kalle>30&&kalle<150)
				{
					if(kalle<90)
				{
					Debug.Log("sain pihta");
				soomuselemojuvjoud=Random.Range(0.8f,1.2f)*kahjustus*(kalle)/100*porkekiirus/20/3;//arvutab, et milline on soomusele mõjuv jõud.
			soomusetugevus=collision.collider.gameObject.GetComponent <Soomusetugevus>().soomusetugevus;//uurib, kui tugev on seal kohas soomus.
					if(soomuselemojuvjoud>soomusetugevus)//kui soomusele mõjuv jõud on tugevam kui soomus.
					{
				aia=Random.Range(0.8f,1.2f)*kahjustus*(kalle)/100*porkekiirus/20/3;//arvutab välja saadava aia hulga. Elud lähevad maha Elu skriptis SaaAia functionis.
				collision.collider.gameObject.SendMessageUpwards("SaaAia",aia);//saadab SaaAia funktsioonile siis saadava aia hulga. SaaAia on Elud skriptis
	/*elukesed=collision.collider.gameObject.GetComponent <Soomusetugevus>().alleselud;
					if(elukesed<1)
					{
					collision.gameObject.transform.position=GameObject.Find("Spawn").transform.position;
					}	*/			
						}
				}
				
				else
				{
					Debug.Log("sain pihta");
				soomuselemojuvjoud=Random.Range(0.8f,1.2f)*kahjustus*(180-kalle)/100*porkekiirus/20;
				soomusetugevus=collision.collider.gameObject.GetComponent <Soomusetugevus>().soomusetugevus;
					if(soomuselemojuvjoud>soomusetugevus)
					{
				aia=Random.Range(0.8f,1.2f)*kahjustus*(180-kalle)/100*porkekiirus/20;
				collision.collider.gameObject.SendMessageUpwards("SaaAia",aia);
						/*elukesed=collision.collider.gameObject.GetComponent <Soomusetugevus>().alleselud;
					if(elukesed<1)
					{
					collision.collider.gameObject.SendMessageUpwards("EludTagasi");
					collision.gameObject.rigidbody.transform.position=GameObject.Find("Spawn").transform.position;
					}*/
					}
				//}
					
			}
		}
			
		}
		
		/*if (hit.collider.gameObject.GetComponent <Eflud>().minuelud>1)
		{
			hit.collider.gameObject.GetComponent <Elud>().minuelud=hit.collider.gameObject.GetComponent <Elud>().minuelud-1;
		}
		else if(hit.collider.gameObject.GetComponent <Elud>().minuelud==1)
		{
			Destroy(hit.gameObject);
		}*/
	}
}
//}

}