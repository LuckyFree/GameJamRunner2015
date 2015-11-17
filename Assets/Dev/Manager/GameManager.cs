using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    //Niveau 1, 2, 3, 4
    //2015, 2004, 1989 et 1972.

    public int level;
    public float distanceMonsterPop;
    public float timerMonsterPop;
    private float timerLeft;
    public int maxNbOfMonsterAlive;
    public int nbOfMonsterAlive;
    private Transform camTransform;
    private LevelManager levelManager;
    private GameObject dynamicHierarchy;

    //Liste des monstres pour chaque niveau
    private Dictionary<int, List<GameObject>> monsters;

	// Use this for initialization
	void Start () {
        dynamicHierarchy = GameObject.Find("DYNAMIC") as GameObject;
        camTransform = GameObject.Find("Main Camera").GetComponent<Transform>();
        levelManager = LevelManager.GetInstance();

        monsters = new Dictionary<int, List<GameObject>>();
        for (int i = 0; i < 4; i++)
            monsters[i] = new List<GameObject>();

        timerLeft = timerMonsterPop;
        RemplirMonstres();
	}
	
	// Update is called once per frame
	void Update () {
        timerLeft -= Time.deltaTime;
        if (timerLeft <= 0 && nbOfMonsterAlive < maxNbOfMonsterAlive)
        {
            PopMonstre();
            timerLeft = timerMonsterPop;
        }	    
	}

    //Rempli la liste de monstre pour chaque niveau, les monstres ont des positions prédéterminées donc pas besoin de les modifier (si sur plusieurs positions, alors plusieurs préfabs)
    private void RemplirMonstres()
    {
        //TODO FINISH IT! WAITING FOR ASSETS
        //Niveau 1
        monsters[0].Add(Resources.Load("Prefabs/Ennemies/Niveau1/Drone") as GameObject);
        monsters[0].Add(Resources.Load("Prefabs/Ennemies/Niveau1/Tank") as GameObject);

        //Niveau2
        monsters[1].Add(Resources.Load("Prefabs/Ennemies/Niveau1/Helicopter") as GameObject);
        monsters[1].Add(Resources.Load("Prefabs/Ennemies/Niveau1/SnakeBox") as GameObject);
    }


    //Fait apparaitre un monstre aléatoire en fonction du niveau en dehors de l'écran
    private void PopMonstre()
    {
        int monsterToGenerate = Random.Range(0, monsters[level].Count);
        Vector3 newPosition = new Vector3(camTransform.position.x + distanceMonsterPop, monsters[level][monsterToGenerate].transform.position.y, 0);

        GameObject newMonster = Instantiate(monsters[level][monsterToGenerate], newPosition, camTransform.rotation) as GameObject;
        newMonster.transform.parent = dynamicHierarchy.transform;
        Renderer rendTemp = newMonster.GetComponent<Renderer>();
        levelManager.GetRendererList().Add(rendTemp);
    }
}
