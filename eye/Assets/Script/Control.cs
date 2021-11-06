using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

	public FollowMouse[] FollowMouse; 
	public GameObject Button;
	public Button BButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		for (int i = 0; i < FollowMouse.Length; i++) {
			if (FollowMouse [i].isGoal == true) {
				Button.SetActive (true);
//				if (BButton.isRevoke == true) 
//					Button.SetActive (true);			
			}
			else
				Button.SetActive (false);
		}
	}
}
