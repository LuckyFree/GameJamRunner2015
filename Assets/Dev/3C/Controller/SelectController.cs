using UnityEngine;
using System.Collections;

public class SelectController : MonoBehaviour {
	int Charac = 0;
	[SerializeField]
	private GameObject Charac0 = null;
	[SerializeField]
	private GameObject Charac1 = null;

	public void NextCharact () {
		if (Charac == 1) {
			Charac = 0;
		}
		else {
			Charac++;
		}
		switch(Charac)
		{
		case 0:
			Charac0.SetActive(true);
			Charac1.SetActive(false);
			break;
		default:
			Charac0.SetActive(false);
			Charac1.SetActive(true);
			break;
		}
	}
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("SelectCharact") == 0)
		{
			Charac = -1;
		}
		else
		{
			Charac = (PlayerPrefs.GetInt("SelectCharact") - 1);
		}
		NextCharact ();  

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
