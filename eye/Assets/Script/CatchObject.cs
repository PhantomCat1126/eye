using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchObject : MonoBehaviour {

	Rigidbody r;
	Vector3 OriginalPos;
	public GameObject AnswerPosition;       // 目標位置 

	bool isCilck = false;
	bool isTarget = false;

	void Awake()
	{
		r = this.GetComponent<Rigidbody>();
		OriginalPos = this.GetComponent<Transform>().position;
		//AnswerPos = AnswerPosition.GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Collider>().tag == AnswerPosition.GetComponent<Collider>().tag)
		{
			GameControl.Instance.inGoal();
			//print("inGoalNum: " + GameControl.inGoalNum);
			transform.position = AnswerPosition.GetComponent<Transform>().position;
		}
	}

	/// <summary>
	/// 當滑鼠按鍵放開時，可觸發此事件。
	/// </summary>
	void OnMouseUp()
	{
		isCilck = false;
	}

	//確認選取
	/// <summary>
	/// 當滑鼠游標已移入觸發區域並且尚未移出觸發區域前，會"持續"觸發此事件
	/// </summary>
	void OnMouseOver()
	{
		isTarget = true;
		//print("isTarget is "+ isTarget);

		if (Input.GetMouseButton(0)) {
			isCilck = true;
			//Updatetransform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smooth);
			print("按下滑鼠左鍵");
		}

	}
	/// <summary>
	/// 當滑鼠游標移入觸發區域時，可觸發此事件。
	/// </summary>
	void OnMouseExit()
	{
		isTarget = false;
		//print("isTarget is " + isTarget);

	}
}
