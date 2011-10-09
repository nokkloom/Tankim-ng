using UnityEngine;
using System.Collections;

public class Raskuspunkt : MonoBehaviour {
public Transform COM;
	// Use this for initialization
	void Start () {
	rigidbody.centerOfMass = COM.localPosition;
	}
	
}
