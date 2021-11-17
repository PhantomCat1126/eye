using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
	public static GameControl Instance;

	[HeaderAttribute("目標位置")]
	public GameObject[] AnswerPosition;       // 目標位置 

	[HeaderAttribute("可移動物件")]
	public GameObject[] FollowMouse;

	public static int inGoalNum = 0;

	public GameObject UIButton;

	// Use this for initialization
	void Awake () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool ReturnBool(bool b) 
	{
		return b;
	}

	public void inGoal() 
	{
		inGoalNum += 1;
		CheckGoal();
	}

	bool CheckGoal() 
	{
		if (inGoalNum == 0) return false;

		if(inGoalNum == AnswerPosition.Length)
        {
			UIButton.SetActive(true);
			return true;
		}
		return true;
	}
}
