using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class ClickBlur : MonoBehaviour {

	public GameObject sDepthOfField;
	public Scrollbar ChangeRotate;
	public Slider SliderChangeRotate;
//	public DepthOfField DepthOfField;
	public Material blur;
	public int blurSizeID;


	// Use this for initialization
	void Start () {
		//Renderer rend = sDepthOfField.GetComponent<Renderer> ();
		//rend.material.shader = Shader.Find("BackBlur");
		blurSizeID = blur.GetInt ("_Size");
	}
	
	// Update is called once per frame
	void Update () {
//		DepthOfField.focalSize =0.1f/ChangeRotate.value;
		blur.SetFloat ("_Size",20*SliderChangeRotate.value);

	}
		
}


