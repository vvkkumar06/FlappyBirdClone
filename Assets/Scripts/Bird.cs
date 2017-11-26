using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bird : MonoBehaviour {


	public static Bird instance;
	[SerializeField] private Rigidbody2D myRigidBody;
	[SerializeField] private Animator anim;
	 private float forwardSpeed = 3f;
	 private float bounceSpeed = 4f;

	 private bool didFlap;
	 public  bool isAlive;
	 private Button flapButton;
	

	void Awake(){
		if(instance == null){
			instance = this;
		}

		isAlive = true;
		flapButton = GameObject.FindGameObjectWithTag ("FlapButton").GetComponent<Button> ();
		flapButton.onClick.AddListener (()=> FlapTheBird ());
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(isAlive){

			Vector3 temp = transform.position;
			temp.x += forwardSpeed * Time.deltaTime;
			transform.position = temp;
			if(didFlap){
				didFlap = false;
				myRigidBody.velocity = new Vector2(0, bounceSpeed);
				anim.SetTrigger ("flap");
				 
			}

			if(myRigidBody.velocity.y >=0){
				float angle = 0;
				angle = Mathf.Lerp(0, 45, myRigidBody.velocity.y/10);
				transform.rotation = Quaternion.Euler(0,0,angle);
			}
			else{
				float angle = 0;
				angle = Mathf.Lerp(0, -90, -myRigidBody.velocity.y/7);
				transform.rotation = Quaternion.Euler (0,0,angle);
			}
		}


	}

	public float getPostionX(){

		return transform.position.x;
	}

	public void FlapTheBird(){
		didFlap = true;
	}

	void SetCameraX(){
		cameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
	}

}
