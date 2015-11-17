using UnityEngine;
using System.Collections;


enum RunnerPosition
{
    TOP, MIDDLE, BOTTOM
}


public class CharacterManager : MonoBehaviour
{

    #region Attributes

    private Transform myTransform;
    private RunnerPosition runnerPosition;
    [SerializeField]
    private float nextPositionDistance;
    [SerializeField]
    private float verticalSpeed;
    [SerializeField]
    private float horizontalSpeed;
    public bool moving;
    public bool movingHorizontal;
    public Vector3 direction;
    public Vector3 directionHorizontal;
    private float movementLeft;
    private float movementLeftHorizontal;
    private float horizontalMovement;

     [SerializeField] 
    private Transform repere1;
     [SerializeField] 
    private Transform repere2;


    // Offset multiplier (between 0 and 1)
    [SerializeField] 
    private float m_OffsetMultiplier = 0.5f;

    // Instance
    public static CharacterManager s_Instance = null;

    #endregion


    #region MonoBehaviour

    // Called at game creation
    void Awake()
    {
        if (s_Instance != null)
        {
            Debug.LogWarning("2 characters in scene, last removed");
            GameObject.Destroy(gameObject);
        }
        else
        {
            s_Instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        myTransform = transform;
        runnerPosition = RunnerPosition.MIDDLE;
        movementLeft = 0;
        moving = false;
        movingHorizontal = false;
        direction = new Vector3(0, 1, 0);
        directionHorizontal = new Vector3(1, 0, 0);
        horizontalMovement = 0;
        repere1 = GameObject.Find("LeftMark").transform;
        repere2 = GameObject.Find("RightMark").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            float amountToMove = Mathf.Min(verticalSpeed * Time.deltaTime, movementLeft);
            movementLeft -= amountToMove;
            myTransform.Translate(direction * amountToMove);
            if (movementLeft <= 0)
                moving = false;
        }
        //if (movingHorizontal)
        //{
        //    float amountToMove = Mathf.Min(horizontalSpeed * Time.deltaTime, movementLeftHorizontal);

        //    movementLeftHorizontal -= amountToMove;
        //    myTransform.Translate(directionHorizontal * amountToMove);
        //    if (movementLeftHorizontal <= 0)
        //        movingHorizontal = false;
        //}
        UpdatePositionOnOffset();
    }

    #endregion

    #region Static Manipulators

    /// <summary>
    /// Get character instance
    /// </summary>
    /// <returns>Character instance</returns>
    public static CharacterManager GetCharacter()
    {
        return s_Instance;
    }

    #endregion

    public void MoveUp()
    {
        //Debug.Log("UP");
        switch (runnerPosition)
        {
            case RunnerPosition.MIDDLE:
                moving = true;
                direction = new Vector3(0, 1, 0);
                movementLeft = nextPositionDistance;
                runnerPosition = RunnerPosition.TOP;
               // Debug.Log("MIDDLE -> TOP");
                break;
            case RunnerPosition.BOTTOM:
                moving = true;
                direction = new Vector3(0, 1, 0);
                movementLeft = nextPositionDistance;
                runnerPosition = RunnerPosition.MIDDLE;
               // Debug.Log("BOTTOM -> MIDDLE");
                break;
        }
    }

    public void MoveDown()
    {
        switch (runnerPosition)
        {
            case RunnerPosition.MIDDLE:
                moving = true;
                direction = new Vector3(0, -1, 0);
                movementLeft = nextPositionDistance;
                runnerPosition = RunnerPosition.BOTTOM;
                break;
            case RunnerPosition.TOP:
                moving = true;
                direction = new Vector3(0, -1, 0);
                movementLeft = nextPositionDistance;
                runnerPosition = RunnerPosition.MIDDLE;
                break;
        }
    }

    #region KEVIN MODIFS

    // Horizontal offset lerp t
    private float m_HorizontalOffsetLerpT = 1;

    /// <summary>
    /// Update position on horizontal offset
    /// </summary>
    private void UpdatePositionOnOffset()
    {
        Vector3 position = transform.position;
        Vector3 horizontalOffset = repere2.position - repere1.position;

        m_HorizontalOffsetLerpT += Time.deltaTime;
        position.x = Mathf.Lerp(repere1.position.x, repere2.position.x, m_OffsetMultiplier);
        position.x = Mathf.Lerp(transform.position.x, position.x, m_HorizontalOffsetLerpT * horizontalSpeed);

        transform.position = position;
    }

    /// <summary>
    /// Decrease offset multiplier with specified value
    /// </summary>
    /// <param name="value">Decrease step</param>
    public void DecOffsetMultiplier(float value)
    {
        float offsetMultiplier = Mathf.Clamp(m_OffsetMultiplier - Mathf.Abs(value), 0, 1);
        m_OffsetMultiplier = offsetMultiplier;
        m_HorizontalOffsetLerpT = 0;
    }

    /// <summary>
    /// Increase offset multiplier with specified value
    /// </summary>
    /// <param name="value">Increase step</param>
    public void IncOffsetMultiplier(float value)
    {
        float offsetMultiplier = Mathf.Clamp(m_OffsetMultiplier + Mathf.Abs(value), 0, 1);
        m_OffsetMultiplier = offsetMultiplier;
        m_HorizontalOffsetLerpT = 0;
    }

    #endregion
}
