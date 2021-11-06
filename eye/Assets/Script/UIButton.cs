using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour {

	public GameObject[] EyeObject;
	public GameObject[] ExplosionPosition;
	public GameObject[] OriginalPosition;
	public float smooth = 5.0F;

	public GameObject btn_on;
	public GameObject btn_off;
	public bool isON=false;
	public bool isOFF=false;

	public bool isExplosion=false;

	public GameObject CrystallineLens;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		print ("isON："+isON+"，isOFF："+isOFF);

		if (isON == true) {
			isOFF = false;
			for (int i = 0; i < EyeObject.Length; i++) {
				EyeObject [i].transform.position = Vector3.Lerp (EyeObject [i].transform.position, ExplosionPosition [i].transform.position, Time.deltaTime * smooth);
				if (EyeObject [i].transform.position == ExplosionPosition [i].transform.position) {
					btn_off.SetActive (true);
					isExplosion = true;
					isON = false;
				}
			}
		}
			
		if (isExplosion == true)
			btn_on.SetActive (false);

		if (isOFF == true) {
			for (int i = 0; i < EyeObject.Length; i++) {
				EyeObject [i].transform.position = Vector3.Lerp (EyeObject [i].transform.position, OriginalPosition [i].transform.position, Time.deltaTime * smooth);
				if (EyeObject [i].transform.position == OriginalPosition [i].transform.position) {
					isExplosion = false;
					btn_off.SetActive (false);
					btn_on.SetActive (true);

				}
			}
		}


	}

	public void ON() 
	{
		isON = true;
	}

	public void OFF() 
	{
		isOFF = true;
	}




	public void AdjustlocalScale(float newlocalScale) 
	{
		CrystallineLens.transform.localScale =Vector3.Lerp(CrystallineLens.transform.localScale,new Vector3 (CrystallineLens.transform.localScale.x, CrystallineLens.transform.localScale.y, newlocalScale*0.5f), Time.deltaTime * smooth  );
	}
}
