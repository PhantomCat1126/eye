using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRotate : MonoBehaviour {

	private Vector3 MousePos;          	   // 滑鼠位置
	private Vector3 TargetPos;            // 目標(自己)物位置
	public Vector3 targetPos;
	Rigidbody r;

	public float smooth = 5.0F;
	public float HorizontalLine=550f;

	public GameObject LeftPosition;
	public Vector3 LeftPos;
	public GameObject RightPosition;
	public Vector3 RightPos;
	public GameObject MiddlePosition;
	Vector3 MiddlePos;

	public GameObject CrystallineLens;
	public float Scale = 0.5f;

	bool isCilck=false;

	public Slider SliderChangeRotate;

	// Use this for initialization
	void Start () {
		r =this.GetComponent<Rigidbody>();
		LeftPos= LeftPosition.GetComponent<Transform> ().position;
		RightPos= RightPosition.GetComponent<Transform> ().position;
		MiddlePos= MiddlePosition.GetComponent<Transform> ().position;
	}
	
	// Update is called once per frame
	void Update () {
		MousePos = Input.mousePosition;

		//r.isKinematic = true;
		//這邊假設你Camera的Z軸在-10而物體的Z軸在0
		targetPos = Camera.main.ScreenToWorldPoint (new Vector3 (MousePos.x, HorizontalLine, 6.8f));

		if (isCilck == true) {
			transform.position = Vector3.Lerp (transform.position, targetPos, Time.deltaTime * smooth);
			r.AddForce (transform.forward * 12F, ForceMode.Impulse);
			CrystallineLens.transform.localScale =Vector3.Lerp(CrystallineLens.transform.localScale,new Vector3 (CrystallineLens.transform.localScale.x, CrystallineLens.transform.localScale.y, (transform.position.x-LeftPosition.transform.position.x) / 10), Time.deltaTime * smooth  );
//			DepthOfField.focalSize = 1f / transform.position.x;

			if (targetPos.x <= LeftPos.x)
				transform.position = LeftPosition.transform.position;
			if (targetPos.x >= RightPos.x)
				transform.position = RightPosition.transform.position;
		}

	}

	void OnMouseEnter()
	{
		this.GetComponent<Renderer> ().material.color = Color.green;
	}

	void OnMouseExit() 
	{
		this.GetComponent<Renderer> ().material.color = Color.white;
	}

	//確認選取
	void OnMouseDown() 
	{
		isCilck = true;
	}
	void OnMouseUp() 
	{
		isCilck = false;
	}

	public void AdjustlocalScale(float newlocalScale) 
	{
		CrystallineLens.transform.localScale =Vector3.Lerp(CrystallineLens.transform.localScale,new Vector3 (CrystallineLens.transform.localScale.x, CrystallineLens.transform.localScale.y, SliderChangeRotate.value*Scale), Time.deltaTime * smooth  );
	}
}
