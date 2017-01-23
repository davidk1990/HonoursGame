using UnityEngine;
using System.Collections;

public class Objectives : MonoBehaviour {

	public GameObject objectiveText;

	// Use this for initialization
	void Start () {
		objectiveText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowObjective(){
		objectiveText.SetActive(true);

	}

	public void HideObjective(){
		objectiveText.SetActive(false);
	}
}
