using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    private Vector2 fingerStartPos = Vector2.zero;
    private float minSwipeDist;
    private bool moving;
    private GameObject player;
    private CharacterManager characterManager;

    public bool invertedControls;

    private float timerTest = 2;

	// Use this for initialization
	void Start () {
        // Screen.SetResolution(256, 240, false); // trying to set the right resolution from NES
        minSwipeDist = 50.0f;
        moving = false;
        player = GameObject.Find("Player");
        characterManager = player.GetComponent<CharacterManager>();
        invertedControls = false;
	}
	
	// Update is called once per frame
	void Update () {

        timerTest -= Time.deltaTime; ;
        if (timerTest <= 0)
        {
            Debug.Log("MOVE UP");
            moving = true;
            characterManager.MoveDown();
            timerTest = 30000;
        }


        if (moving)
        {
            if (!characterManager.moving)
                moving = false;
        }

        if (CanMove())
        {
            Move();
        }
	}

    private bool CanMove() // TODO Check if you can move (not moving and something else?)
    {
        return !moving;
    }

    /// <summary>
    /// Check if the input is asking for a movement up or down
    /// </summary>
    private void Move()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        /* this is a new touch */
                        fingerStartPos = touch.position;
                        break;

                    case TouchPhase.Ended:
                        float gestureDist = (touch.position - fingerStartPos).magnitude;
                        //Debug.Log("====Avant entrée dans gesture");
                        if (gestureDist > minSwipeDist)
                        {
                           // Debug.Log("========Entrée dans gesture");
                            Vector2 direction = touch.position - fingerStartPos;
                            Vector2 swipeType = Vector2.zero;

                            if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
                            {
                                // the swipe is vertical:
                                swipeType = Vector2.up * Mathf.Sign(direction.y);

                                if (swipeType.y != 0.0f)
                                {
                                    if (swipeType.y > 0.0f)
                                    {
                                        if (!invertedControls)
                                        {
                                            Debug.Log("MOVE UP");
                                            moving = true;
                                            characterManager.MoveUp();
                                        }
                                        else 
                                        {
                                            Debug.Log("MOVE DOWN (INVERTED)");
                                            moving = true;
                                            characterManager.MoveDown();
                                        }
                                    }
                                    else
                                    {
                                        if (!invertedControls)
                                        {
                                            Debug.Log("MOVE DOWN");
                                            moving = true;
                                            characterManager.MoveDown();
                                        }
                                        else
                                        {
                                            Debug.Log("MOVE UP (INVERTED)");
                                            moving = true;
                                            characterManager.MoveUp();
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}
