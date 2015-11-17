using UnityEngine;
using System.Collections;

public class MenuControlleur : MonoBehaviour {

	public void StartGame()
	{
		Application.LoadLevel("ProtoA");
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
