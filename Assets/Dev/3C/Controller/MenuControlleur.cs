using UnityEngine;
using System.Collections;

public class MenuControlleur : MonoBehaviour {

	public void StartGame()
	{
		Debug.Log("Test Menu");
		Application.LoadLevel("ProtoA");
	}

	public void SelectDifficulty()
	{
		Application.LoadLevel("SelectDifficulty");
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
