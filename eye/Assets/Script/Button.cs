using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public GameObject[] EyeObject;
	public GameObject[] ExplosionPosition;
	public GameObject[] OriginalPosition;
	public float smooth = 5.0F;

	public GameObject btn_on;
	public GameObject btn_off;
	bool isbtn_on=false;
	bool isbtn_off=false;

	public bool isON=false;
	public bool isOFF=false;

	public bool isExplosion=false;
	public bool isRevoke=true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isbtn_on == true) {				
			if (Input.GetMouseButton (0)) {
				isON = true;
				btn_on.SetActive (false);
			}
		}
		if (isON == true) {
			isOFF = false;
			for (int i = 0; i < EyeObject.Length; i++) {
				EyeObject [i].transform.position = Vector3.Lerp (EyeObject [i].transform.position, ExplosionPosition [i].transform.position, Time.deltaTime * smooth);
				if (EyeObject [i].transform.position == ExplosionPosition [i].transform.position) {
					btn_off.SetActive (true);
					isExplosion = true;
					isbtn_on = isON = isRevoke = false;
				}
			}
		}

		if (isExplosion == true)
			btn_on.SetActive (false);


		if (isbtn_off == true) {				
			if (Input.GetMouseButton (0))
				isOFF = true;
			
		}

		if (isOFF == true) {
			for (int i = 0; i < EyeObject.Length; i++) {
				EyeObject [i].transform.position = Vector3.Lerp (EyeObject [i].transform.position, OriginalPosition [i].transform.position, Time.deltaTime * smooth);
				if (EyeObject [i].transform.position == OriginalPosition [i].transform.position) {
					isExplosion = false;
					isRevoke = true;
					btn_off.SetActive (false);

				}
			}
		}
	}
			
	void OnMouseEnter() 
	{
		btn_on.gameObject.GetComponent<Renderer>().material.color=Color.red;
		if(btn_on.active!=false)
			isbtn_on = true;
		else
			isbtn_on = false;
		
		btn_off.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
		if(btn_off.active!=false)
			isbtn_off = true;
		else
			isbtn_off = false;
	}

	void OnMouseExit() 
	{
		btn_on.gameObject.GetComponent<Renderer>().material.color=btn_off.gameObject.GetComponent<Renderer>().material.color=Color.white;
		isbtn_on = isbtn_off = false;
	}
			

}
