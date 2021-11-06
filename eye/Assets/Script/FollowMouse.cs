using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

	public GameObject OriginalPosition;
	Vector3 OriginalPos;            		 // 物位原位置 
	public GameObject AnswerPosition;		// 目標位置 
	Vector3  AnswerPos;
	public GameObject[] ChildrenObject;		// 子物件 

	private Vector3 MousePos;          	   // 滑鼠位置
	private Vector3 TargetPos;            // 目標(自己)物位置
	Vector3 targetPos;
	Rigidbody r;
	public float smooth = 5.0F;
	public bool isCilck=false;
	bool isTarget=false;
	public bool isGoal=false;

	// Use this for initialization
	void Start () 
	{
		r =this.GetComponent<Rigidbody>();
		OriginalPos = OriginalPosition.GetComponent<Transform> ().position;
		AnswerPos = AnswerPosition.GetComponent<Transform> ().position;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (isGoal == false) {
			//回到原位
			if (isCilck == false)
				transform.position = Vector3.Lerp (transform.position, OriginalPos, Time.deltaTime * smooth);

			MousePos = Input.mousePosition;             // 輸入滑鼠位置

			//r.isKinematic = true;
			//這邊假設你Camera的Z軸在-10而物體的Z軸在0
			targetPos = Camera.main.ScreenToWorldPoint (new Vector3 (MousePos.x, MousePos.y, 4f)); 

			if (isTarget == true) {
				if (Input.GetMouseButton (0)) {
					isCilck = true;
					transform.position = Vector3.Lerp (transform.position, targetPos, Time.deltaTime * smooth);
					r.AddForce (transform.forward * 12F, ForceMode.Impulse);

				} 
			}
			
		} else {
			
			for (int i = 0; i < ChildrenObject.Length; i++) {
				ChildrenObject[i].GetComponent<Renderer>().material.color=Color.white;
			}
		}


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Collider> ().tag ==AnswerPosition.GetComponent<Collider> ().tag) 
		{
			isGoal = true;
			transform.position = AnswerPos;

			//print (AnswerPosition.GetComponent<Collider> ().tag.ToString());
		}
	}

	void OnMouseUp()
	{
		isCilck=false;
	}

	//確認選取
	void OnMouseEnter() 
	{
		
		isTarget = true;
//		for (int i = 0; i < ChildrenObject.Length; i++) {
//			ChildrenObject[i].GetComponent<Renderer>().material.color=Color.yellow;
//		}

	}
	void OnMouseExit() 
	{
		isTarget = false;
//		for (int i = 0; i < ChildrenObject.Length; i++) {
//			ChildrenObject[i].GetComponent<Renderer>().material.color=Color.white;
//		}

	}

}
