using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour {


	private GameObject[] Backgrounds;
	private GameObject[] Grounds;

	private float LastBGX;
	private float LastGNDX;


	void Awake(){

		Backgrounds = GameObject.FindGameObjectsWithTag ("Background");
		Grounds = GameObject.FindGameObjectsWithTag ("Ground");

		LastBGX = Backgrounds[0].transform.position.x;
		LastGNDX = Grounds[0].transform.position.x;

		for(int i =0; i<Backgrounds.Length; i++){

			if(LastBGX < Backgrounds[i].transform.position.x){
				LastBGX = Backgrounds[i].transform.position.x;
			}
		}
		for(int i =0; i<Grounds.Length; i++){

			if(LastGNDX < Grounds[i].transform.position.x){
				LastGNDX =Grounds[i].transform.position.x;
			}
		}
	}

	void Start ()
	{

		
	}



	void OnTriggerEnter2D(Collider2D target){

		if(target.tag =="Background"){
			
			float width = ((BoxCollider2D)target).size.x;
			Vector3 temp = target.transform.position;
			temp.x = LastBGX + width;
			target.transform.position = temp;
			LastBGX = temp.x;
		}
		if(target.tag =="Ground"){

			float width = ((BoxCollider2D)target).size.x;
			Vector3 temp = target.transform.position;
			temp.x = LastGNDX + width;
			target.transform.position = temp;
			LastGNDX = temp.x;
		}

	}



}
