using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollector : MonoBehaviour {


	private GameObject[] pipeHolders;
	private float LastPipeX;
	private float PipeMinY = -3.16f;
	private float PipeMaxY = 0.6f;
	private float DistanceBetweenPipes =2.5f;


	void Awake(){

		pipeHolders = GameObject.FindGameObjectsWithTag ("PipeHolder");  // Takes all pipes in pipeholders array[]

		LastPipeX = pipeHolders[0].transform.position.x;

		for(int i=0; i<pipeHolders.Length; i++){                         //Running loop as many times as no of pipes available

				Vector3 temp =  pipeHolders[i].transform.position;
				temp.y = Random.Range (PipeMinY, PipeMaxY);
				pipeHolders[i].transform.position = temp;
		}

		for(int i=1; i<pipeHolders.Length; i++){

			if(LastPipeX < pipeHolders[i].transform.position.x){

					LastPipeX = pipeHolders[i].transform.position.x;
				}
		}

	}

	void OnTriggerEnter2D(Collider2D target){

		if(target.tag == "PipeHolder"){
			Vector3 temp = target.transform.position;
			temp.x = LastPipeX + DistanceBetweenPipes;
			temp.y = Random.Range (PipeMinY,PipeMaxY);
			target.transform.position = temp;

			LastPipeX = temp.x;
		}
	}


}
