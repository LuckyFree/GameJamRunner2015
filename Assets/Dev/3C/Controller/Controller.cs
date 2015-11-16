using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    private Vector2 fingerStartPos = Vector2.zero;
    private float minSwipeDist;
    private bool moving;
    private float timeToMove;

	// Use this for initialization
	void Start () {
        minSwipeDist = 50.0f;
        moving = false;
        timeToMove = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (moving)
        {
            timeToMove -= Time.deltaTime;
            if (timeToMove <= 0)
                moving = false;
        }

        if (CanMove())
        {
            Move();
        }
	}

    private bool CanMove() // TODO Check if you can move (not moving)
    {
        return !moving;
    }

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

                        if (gestureDist < minSwipeDist)
                        {
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
                                        // MOVE UP TODO call manager's method moveUp
                                        // TODO  timeToMove = X
                                        //TODO moving = true
                                        Debug.Log("MOVE UP");
                                    }
                                    else
                                    {
                                        // MOVE DOWN TODO call manager's method movedown
                                        // TODO  timeToMove = X
                                        //TODO moving = true
                                        Debug.Log("MOVE DOWN");
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
