// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class tornip88raja3 : MonoBehaviour {
/// This behavior script rotates an object by the mouse delta 
public Transform turret;
public Transform gun;
// All public variables are visible in the inspector and can be edited there. 
public float speed= 0.9f; 
public float x= 0.0f;
public float y= 0.0f;
public float tx= 0.0f;
public Transform target1, target2;
	//raycasti proov.
void Update () {
		//if (Input.GetMouseButton(0)) {
/*			Ray ray = gun.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform == target1) {
					Debug.Log("Hit target 1");
				} else if (hit.transform == target2) {
					Debug.Log("Hit target 2");
				}
			} else {
				Debug.Log("Hit nothing");
			}*/
		}
	
void  PooraTorni (float[] pooramisandmed){ 
x += pooramisandmed[0] * speed; 
y += pooramisandmed[1] * speed; 

   x = Mathf.Clamp (x, -3.0f, 3.0f);
   y = Mathf.Clamp (y, -5.0f, 10.0f);

    gun.transform.localRotation = Quaternion.identity;

gun.transform.Rotate (-y, x, 0);


     gun.transform.Rotate (-y, x, 0);
	 
	 if(x > 2|| x <-2){
	 tx += Input.GetAxis ("Mouse X") * speed;
	 
	 turret.transform.localRotation = Quaternion.identity;
	 turret.transform.Rotate ( 0, tx, 0);
	 
	 }
}


}