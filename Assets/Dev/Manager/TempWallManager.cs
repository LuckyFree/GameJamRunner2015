using UnityEngine;
using System.Collections;

public class TempWallManager : MonoBehaviour {

    public float speed;
    private float pointOfDestructionX;
    private float pointOfNewX;
    private Transform myTransform;
    private Vector3 direction;
    private GameObject prefabWall;
    private bool nextWallCreated;

	// Use this for initialization
	void Start () {
        pointOfNewX = -200;
        pointOfDestructionX = -800;
        myTransform = this.transform;
        direction = new Vector3(-1, 0, 0);
        prefabWall = Resources.Load("Prefabs/TempMur3") as GameObject;
        Debug.Log("helllo" + prefabWall.transform.position.x);
        nextWallCreated = false;
	}
	
	// Update is called once per frame
	void Update () {

        float amountToMove = speed * Time.deltaTime;
        myTransform.Translate(direction * amountToMove);

        if (!nextWallCreated && myTransform.position.x <= pointOfNewX)
        {
            Vector3 deplacement = new Vector3(1000, 0, 0);

            Instantiate(prefabWall, myTransform.position + deplacement, myTransform.rotation);
            nextWallCreated = true;
            Debug.Log("Next wall created");
        }
        if (myTransform.position.x <= pointOfDestructionX)
        {
            Destroy(this.gameObject);
        }
	}
}
