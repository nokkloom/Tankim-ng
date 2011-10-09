/*using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour{

//public GameObject myrsk;


	void Awake(){

		tankShell GameObject;
		boomNoise AudioClip;
	}
*/using UnityEngine;
using System.Collections;

public class Laskmine : MonoBehaviour {
    public GameObject Tank_Shell;
    public float tulesagedus = 3.5F;//see määrab, kui tihedalt saab lasta.
//    private float nextFire = 0.0F;
	public float ebatapsus = 0.6F;
	public float kiirtulesagedus = 0.5F;
	public float powerOfShot=30f;
	public float suund=0.0f;
    /*void Update() {
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
			if(GameObject.FindWithTag("CV-90"))
				{
				lask();
				}
		}
			;
		if (Input.GetButton("Fire2") && Time.time > nextFire)
		{
			if(GameObject.FindWithTag("CV-90"))
			{
			StartCoroutine(laskmine(kiirtulesagedus));
			}
		}
	}*/
	void lask()
	{
		if(GameObject.FindWithTag("Test-kere"))
		{
          //  nextFire = Time.time + tulesagedus;
            GameObject clone = Network.Instantiate(Tank_Shell, transform.position, transform.rotation,0) as GameObject; // Instantiates a projectile facing forward relative to the current forward vector
        clone.rigidbody.AddRelativeForce(Vector3.forward * powerOfShot, ForceMode.Impulse);
		}
	}
		IEnumerator laskmine(float kiirtulesagedus)
			{
			/*for (int i=0; i<3;i++)
			{
				if (Time.time > kiirtulilask)
					{
            kiirtulilask = Time.time + kiirtulesagedus;
            GameObject clone = Instantiate(Tank_Shell, transform.position, transform.rotation) as GameObject; // Instantiates a projectile facing forward relative to the current forward vector
        clone.rigidbody.AddRelativeForce(Vector3.forward * powerOfShot, ForceMode.Impulse);
					break;
					}
				if (Time.time < kiirtulilask)
					{
					continue;
					}
			*/
		if(GameObject.FindWithTag("Test-kere"))
			{
			for(int i=0;i<3;i++)
			{
 //suund = Vector3.Slerp (transform.TransformDirection(Vector3.forward), Random.onUnitSphere, ebatapsus);		nextFire = Time.time + kiirtulesagedus;
		float randomNumberX = Random.Range(-ebatapsus, ebatapsus);
		float randomNumberY = Random.Range(-ebatapsus, ebatapsus);
        float randomNumberZ = Random.Range(-ebatapsus, ebatapsus);

		//nextFire = Time.time + tulesagedus;
		GameObject clone = Network.Instantiate(Tank_Shell, transform.position, transform.rotation,0) as GameObject; // Instantiates a projectile facing forward relative to the current forward vector
		clone.transform.Rotate(randomNumberX, randomNumberY,randomNumberZ);
		clone.rigidbody.AddRelativeForce(Vector3.forward * powerOfShot, ForceMode.Impulse);
		yield return new WaitForSeconds(kiirtulesagedus);
		
				}
		}
	}
}	
    



	/*
	if (Input.GetKey(KeyCode.Space)) {
		
		if(timer >= timerMax) {
			shootProjectile();
		}
	}
if  (Input.GetKey(KeyCode.Space)) {

GameObject clone = Instantiate(Tank_Shell, transform.position, transform.rotation);
clone.timeoutDestructor = 5;
}
}
/*
void shootProjectile() {
	timer = 0; 
	myrsk = new GameObject("Tank Shell");
	//myrsk = Instantiate(myrsk, transform.position, transform.rotation);
	myrsk.transform.position=transform.position;
	myrsk.transform.rotation=transform.rotation;
myrsk.AddComponent("Rigidbody");
	//audio.PlayOneShot(boomNoise);
	myrsk.rigidbody.AddRelativeForce(Vector3.forward * powerOfShot, ForceMode.Impulse);
	}
}
*/