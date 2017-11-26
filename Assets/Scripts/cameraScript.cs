using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

	public static float offsetX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Checking if Bird Game Object is available or not in scene
		//Checking if Bird is alive or not.. 
		//calling Bird Class -> isAlive boolean variable

		if (Bird.instance != null) {
			if (Bird.instance.isAlive) {
				MoveTheCamera ();
			}
		}


	}



	 void MoveTheCamera(){

	 	Vector3 temp = transform.position;
	 	temp.x = Bird.instance.getPostionX () + offsetX;
	 	transform.position = temp;


	 }
}
